﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowflake.Emulator;
using Snowflake.Records.Game;
using Snowflake.Configuration;

namespace Snowflake.Plugin.EmulatorAdapter.RetroArch.Adapters
{
    public class RetroArchNestopiaAdapter : IEmulatorAdapter
    {
        public string PluginName => "Nestopia (RetroArch)";

        public IList<string> SupportedMimetypes => new List<string>()
        {
            {"application/x-romfile-nes-ines"} //todo optimize
        };

        public IEmulatorInstance Instantiate(IGameRecord record, IList<IConfigurationCollection> configuration)
        {
            throw new NotImplementedException();
        }
    }
}