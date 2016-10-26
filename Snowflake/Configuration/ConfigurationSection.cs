﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Castle.DynamicProxy;
using NLog.LayoutRenderers.Wrappers;
using Snowflake.Configuration.Attributes;
using Snowflake.DynamicConfiguration.Interceptors;

namespace Snowflake.Configuration
{
    public class ConfigurationSection<T> : IConfigurationSection<T> where T : class, IConfigurationSection<T>
    {
        public T Configuration { get; }
        public string Destination { get; }
        public string Description { get; }
        public string DisplayName { get; }
        public string SectionName { get; }
        public IEnumerable<IConfigurationOption> Options { get; }

        public IDictionary<string, IConfigurationValue> Values
            => ImmutableDictionary.CreateRange(this.configurationInterceptor.Values);

        public object this[string key]
        {
            get { return configurationInterceptor.Values[key]; }
            set { this.configurationInterceptor.Values[key].Value = value; }
        }

        private readonly ConfigurationInterceptor configurationInterceptor;

        public ConfigurationSection(string destinationFile, string sectionName, string displayName,
            string description = "")
            : this(destinationFile, sectionName, displayName, new Dictionary<string, IConfigurationValue>(), description
                )
        {
        }

        public ConfigurationSection(string destinationFile, string sectionName, string displayName,
            IDictionary<string, IConfigurationValue> values, string description = "")
        {
            this.Destination = destinationFile;
            this.SectionName = sectionName;
            this.DisplayName = displayName;
            this.Description = description;
            ProxyGenerator generator = new ProxyGenerator();
            var options = from prop in typeof(T).GetProperties()
                where prop.HasAttribute<ConfigurationOptionAttribute>()
                let attr = prop.GetCustomAttribute<ConfigurationOptionAttribute>()
                let name = prop.Name
                let metadata = prop.GetCustomAttributes<CustomMetadataAttribute>()
                select new ConfigurationOption(attr, metadata, name) as IConfigurationOption;

            this.Options = ImmutableList.CreateRange(options);
            this.configurationInterceptor =
                new ConfigurationInterceptor(this.Options.ToDictionary(p => p, p => p.Default));
            foreach (var custom in values)
            {
                this.configurationInterceptor.Values[custom.Key] = custom.Value;
            }
            this.Configuration =
                generator.CreateInterfaceProxyWithoutTarget<T>(new ConfigurationCircularInterceptor<T>(this),
                    configurationInterceptor);
        }

    
    }



}
