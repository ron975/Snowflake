﻿using Snowflake.Extensibility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Snowflake.Services;
using System.Collections.Concurrent;
using Snowflake.Utility;
using System.Reflection;

namespace Snowflake.Framework.Loader.ExtensibilityLoader
{
    public class PluginContainerComposer
    {
        private IList<Module> pluginModules;
        private IList<IPluginContainer> pluginContainers;
        private ICoreService coreService;

        public PluginContainerComposer(ICoreService coreService, ModuleEnumerator modules)
        {
            this.coreService = coreService;
            var assemblyLoader = new AssemblyModuleLoader();
            this.pluginModules = modules.Modules.Where(module => module.Loader == "assembly")
                .Where(module => module.LoaderOptions.composer == "plugincontainer").ToList();
            this.pluginContainers = (from module in this.pluginModules
                                     from pluginContainer in assemblyLoader.LoadModule(module)
                                     select pluginContainer).ToList();
        }

        private IList<string> GetImportedServices(IPluginContainer container)
        {
            var attributes = container.GetType().GetMethod(nameof(IPluginContainer.Compose))
                .GetCustomAttributes<ImportServiceAttribute>();
            return attributes.Select(a => a.Service.FullName).ToList();
        }

        public void Compose()
        {
            var toCompose = this.pluginContainers.Select(p => (plugin: p, services: this.GetImportedServices(p))).ToList();
            int count = toCompose.Count();
            while (count > 0)
            {
                int prevCount = count;
                foreach (var uncomposed in toCompose.ToList())
                {
                    if (this.coreService.AvailableServices().ContainsAll(uncomposed.services))
                    {
                        Console.WriteLine($"Composing {uncomposed.plugin.GetType().Name} with services {String.Join(" ", uncomposed.services)}");
                        this.ComposeContainer(uncomposed.plugin, uncomposed.services);
                        toCompose.Remove(uncomposed);
                    }
                }
                count = toCompose.Count();
                if (prevCount == count) break; //no change
            }
        }

        private void ComposeContainer(IPluginContainer pluginContainer, IList<string> services)
        {
            Console.WriteLine($"Composing {pluginContainer.GetType().Name}");
            IServiceContainer container = new ServiceContainer(this.coreService, services);
            pluginContainer.Compose(container);
            Console.WriteLine($"Finished composing {pluginContainer.GetType().Name}");
        }
    }
}
