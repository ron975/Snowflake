﻿using System.Diagnostics;
using System.IO;

namespace Snowflake.Plugin.EmulatorAdapter.RetroArch.Executable
{
    internal class RetroArchProcessInfo 
    {

        public string ConfigPath { private get; set; }
        public string CorePath { private get; set; }
        public string SavePath { private get; set; }
        public string Subsystem { private get; set; }
        public bool Debug { private get; set; }
        private readonly string retroArchDirectory;
        private readonly string romFile;
        public RetroArchProcessInfo(string retroArchDirectory, string romFile)
        {
            this.retroArchDirectory = retroArchDirectory;
            this.romFile = romFile;
        }

        public ProcessStartInfo GetStartInfo()
        {
            return new ProcessStartInfo(Path.Combine(this.retroArchDirectory, this.Debug ? "retorarch_debug" : "retroarch"))
            {
                WorkingDirectory = this.retroArchDirectory, 
                Arguments = $@"{(this.Debug ? "-v ": @"""")}{this.GetArgument(this.SavePath, "-s")}{this.GetArgument(this.ConfigPath, "-c")}{this.GetArgument(this.CorePath, "-L")}""{this.romFile}"" {this.GetArgument(this.Subsystem, "--subsystem")}",
            };
        }

        internal string GetArgument(string value, string argumentName)
        {
            return value != null ? $@"{argumentName} ""{value} """ : "";
        }
    }
}
