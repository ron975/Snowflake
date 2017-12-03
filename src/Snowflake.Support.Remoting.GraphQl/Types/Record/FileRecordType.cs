﻿using GraphQL.Conventions.Adapters.Types;
using GraphQL.Types;
using Snowflake.Records.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snowflake.Support.Remoting.GraphQl.Types.Record
{
    public class FileRecordType : ObjectGraphType<IFileRecord>
    {
        public FileRecordType()
        {
            Name = "FileRecord";
            Description = "A record of a file related to a game or other metadatable record.";
            Field(f => f.FilePath).Description("The path to the file.");
            Field(f => f.MimeType).Description("The file's mimetype.");
            Field<GuidGraphType>("guid",
              description: "The unique ID of the game.",
              resolve: context => context.Source);
            Field<ListGraphType<RecordMetadataType>>(
                "metadata",
                description: "A list of metadata related to this game.",
                resolve: context => context.Source.Metadata.Select(m => m.Value)
                );
            Interface<RecordInterface>();
        }
    }
}
