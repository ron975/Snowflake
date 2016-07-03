﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowflake.Records.Game;
using Snowflake.Romfile;
using System.IO.Compression;
using Snowflake.Platform;
using Snowflake.Records.File;
using Snowflake.Records.Metadata;
using Snowflake.Scraper.Providers;
using Snowflake.Scraper.Shiragame;
using Snowflake.Service;
using Snowflake.Utility;

namespace Snowflake.Scraper
{
    public interface IScrapeEngine
    {
        IFileRecord GetFileInformation(string romfile);

    }

    public class ScraperGenerator : IScrapeEngine
    {
        private readonly IStoneProvider stoneProvider;
        private readonly IShiragameProvider shiragameProvider;
        private readonly IList<IScrapeProvider<IScrapedMetadataCollection>> providers;
        private readonly ILookup<string, string> validMimetypes;
        private readonly IList<string> validFileExtensions;
        private readonly IFileSignatureMatcher fileSignatures;
    
        public ScraperGenerator 
            (IStoneProvider stoneProvider,
            IShiragameProvider shiragameProvider,
            IList<IScrapeProvider<IScrapedMetadataCollection>> providers,
            IFileSignatureMatcher fileSignatures)
        {
            this.stoneProvider = stoneProvider;
            this.shiragameProvider = shiragameProvider;
            this.providers = providers;
            this.fileSignatures = fileSignatures;
            this.validMimetypes = (from platform in this.stoneProvider.Platforms.Values
                                  from fileType in platform.FileTypes
                                  select new KeyValuePair<string, string>(fileType.Value, fileType.Key)).
                                  ToLookup(t => t.Key, t => t.Value);
            this.validFileExtensions = (from mimetype in this.validMimetypes
                                        from ext in mimetype
                                        select ext).Distinct().ToList();
        }

        public IGameRecord GetGameRecordFromFiles(IFileRecord fileRecord)
        {
            var gr = new GameRecord(this.stoneProvider.Platforms[fileRecord.Metadata[FileMetadataKeys.RomPlatform]], 
                fileRecord.Metadata[FileMetadataKeys.RomCanonicalTitle]);
            gr.Files.Add(fileRecord);
            //merge scrape resu;ts
            var matches = this.providers.Select(x => x.Query(fileRecord.Metadata));
            var _matches = matches.OrderByDescending(result => result.Accuracy).Select(x => x as IMetadataCollection);
            var bestMatch = _matches.First();
            foreach (string key in bestMatch.Keys)
            {
                gr.Metadata[key] = bestMatch[key]; //copy keys
            }
            //.. and so forth
            // ssomehow merge all provider data? I don't know...
            //.. do run enabled mediaproviders
            //need to test
            return gr; //use plinq here.
        }

        public IFileRecord GetFileInformation(string romfile)
        {
            string ext = Path.GetExtension(romfile)?.ToLowerInvariant();
            if (ext == ".zip")
            {
                return this.shiragameProvider.IsMameRom(romfile) ? this.GetMameInformation(romfile) 
                    : this.GetZipStreamInformation(romfile);
            }
            if (!this.validFileExtensions.Contains(ext)) return null; 
            //hopefully this doesn't come back to bite me in the ass.
            //this will break for any nonstandard file extensions
            using (Stream romStream = File.Open(romfile, FileMode.Open, FileAccess.Read))
            {
                return this.GetFileInformation(romfile, romStream);
            }

        }

        IFileRecord GetMameInformation(string mameFile)
        {
            var record = new FileRecord(mameFile, "application/x-romfile-arcade+zip");
            record.Metadata.Add("rom_platform", "ARCADE_MAME");
            record.Metadata.Add("rom_serial", Path.GetFileNameWithoutExtension(mameFile));
            return record;
        }

        IFileRecord GetZipStreamInformation(string zipFile)
        {
            using (ZipArchive archive = new ZipArchive(File.OpenRead(zipFile), ZipArchiveMode.Read))
            {
                var firstEntry = (from entry in archive.Entries
                                  let extension = Path.GetExtension(entry.FullName)?.ToLowerInvariant()
                                  where this.validFileExtensions.Contains(extension) 
                                  //hopefully this doesn't come back to bite me in the ass.
                                  where extension != ".zip"
                                  select entry).FirstOrDefault();
                if (firstEntry == null) return null;
                Stream deflatedStream = new MemoryStream();
                using (var stream = firstEntry.Open())
                {
                    stream.CopyTo(deflatedStream);
                }
                IFileRecord romRecord = this.GetFileInformation(firstEntry.FullName, deflatedStream);
                IFileRecord zipRecord = new FileRecord(zipFile, $"{romRecord.MimeType}+zip");
                zipRecord.Metadata.Add(romRecord.Metadata);
                zipRecord.Metadata.Add(FileMetadataKeys.RomZipRunnableFilename, firstEntry.FullName);
                return zipRecord;
            }

        }

        IFileRecord GetFileInformation(string romfile, Stream romStream)
        {
            string ext = Path.GetExtension(romfile)?.ToLowerInvariant();
            var potentialMimetypes = (from mimetype in this.validMimetypes
                                      where mimetype.Contains(ext)
                                      select mimetype.Key).ToList();

            if (!potentialMimetypes.Any()) return null;

            var romInfo = this.fileSignatures.GetInfo(romfile, romStream);
            var fileInfo =  romInfo?.Serial == null ? 
                this.GetFromHash(romfile, romInfo, romStream) 
                : this.GetFromSerial(romfile, romInfo, romStream);
            romStream.Close();
            return fileInfo;
        }

        IFileRecord GuessFromFile(string romfile, IRomFileInfo romFileInfo)
        {
            var fileNameData = new StructuredFilename(romfile);
            IFileRecord record = new FileRecord(romfile, romFileInfo.Mimetype);
            if (romFileInfo.InternalName != null)
                record.Metadata.Add(FileMetadataKeys.RomInternalName, romFileInfo.InternalName);
            if (romFileInfo.Serial != null)
                record.Metadata.Add(FileMetadataKeys.RomSerial, romFileInfo.Serial);
            var gamePlatform =
              this.stoneProvider.Platforms.First(p => p.Value.FileTypes.Values.Contains(romFileInfo.Mimetype)).Value;
            record.Metadata.Add(FileMetadataKeys.RomPlatform, gamePlatform.PlatformID);
            record.Metadata.Add(FileMetadataKeys.RomCanonicalTitle, fileNameData.Title);
            record.Metadata.Add("result_guessed", "true");
            record.Metadata.Add(FileMetadataKeys.RomRegion, fileNameData.RegionCode);
            return record;
        }
        
        IFileRecord GetFromHash(string romfile, IRomFileInfo romFileInfo, Stream romStream)
        {
            string hash = FileHash.GetMD5(romStream);
            var romInfo = this.shiragameProvider.GetFromMd5(hash);
            if (romInfo == null) return this.GuessFromFile(romfile, romFileInfo); 
            IFileRecord record = new FileRecord(romfile, romInfo.MimeType);
            if (romFileInfo.InternalName != null)
                record.Metadata.Add(FileMetadataKeys.RomInternalName, romFileInfo.InternalName);
            record.Metadata.Add(FileMetadataKeys.RomRegion, romInfo.Region);
            record.Metadata.Add(FileMetadataKeys.FileHashMd5, romInfo.MD5);
            record.Metadata.Add(FileMetadataKeys.FileHashSha1, romInfo.SHA1);
            record.Metadata.Add(FileMetadataKeys.FileHashCrc32, romInfo.CRC32);
            record.Metadata.Add(FileMetadataKeys.RomCanonicalTitle, new StructuredFilename(romInfo.FileName).Title);
            record.Metadata.Add(FileMetadataKeys.RomPlatform, romInfo.PlatformId);
            return record;
        }

        IFileRecord GetFromSerial(string romfile, IRomFileInfo romInfo, Stream romStream)
        {
            var gamePlatform =
                this.stoneProvider.Platforms.First(p => p.Value.FileTypes.Values.Contains(romInfo.Mimetype)).Value;
            string romSerial = romInfo.Serial;
            string mimeType = romInfo.Mimetype;
            IFileRecord record = new FileRecord(romfile, $"{mimeType}");
            if(romInfo.InternalName != null)
                record.Metadata.Add(FileMetadataKeys.RomInternalName, romInfo.InternalName);
            record.Metadata.Add(FileMetadataKeys.RomSerial, romSerial);
            var serialInfo = this.shiragameProvider.GetFromSerial(gamePlatform.PlatformID, romSerial);
            if (serialInfo == null)
                return this.GetFromHash(romfile, romInfo, romStream); //fallback to hash
            record.Metadata.Add(FileMetadataKeys.RomCanonicalTitle, serialInfo.Title);
            record.Metadata.Add(FileMetadataKeys.RomRegion, serialInfo.Region);
            record.Metadata.Add(FileMetadataKeys.RomPlatform, gamePlatform.PlatformID);
            return record;
        }

    }
}
