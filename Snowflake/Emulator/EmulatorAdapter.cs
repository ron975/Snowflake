﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snowflake.Configuration;
using Snowflake.Extensibility;
using Snowflake.Service;

namespace Snowflake.Emulator
{
    public class EmulatorAdapter : Plugin
    {
        public EmulatorAdapter(ICoreService coreInstance) : base(coreInstance.AppDataDirectory)
        {
            //todo implement this.
        }
    }
}