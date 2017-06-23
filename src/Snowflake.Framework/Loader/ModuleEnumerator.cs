﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Runtime;
using System.Runtime.Loader;
using Snowflake.Extensibility;
using Snowflake.Utility;
using Newtonsoft.Json;

namespace Snowflake.Loader
{
    internal class ModuleEnumerator : IModuleEnumerator
    {
        private DirectoryInfo ModuleDirectory { get; }
        public IEnumerable<IModule> Modules { get; }
        public ModuleEnumerator(string appDataDirectory)
        {
            this.ModuleDirectory = new DirectoryInfo(Path.Combine(appDataDirectory, "modules"));
            this.Modules = this.EnumerateModules().ToList();
        }

        private IEnumerable<IModule> EnumerateModules()
        {
            return (from directory in this.ModuleDirectory.EnumerateDirectories()
                    where File.Exists(Path.Combine(directory.FullName, "module.json"))
                    select JsonConvert.DeserializeObject<ModuleDefinition>
                        (File.ReadAllText(Path.Combine(directory.FullName, "module.json")))
                        .ToModule(directory));
        }
    }
}