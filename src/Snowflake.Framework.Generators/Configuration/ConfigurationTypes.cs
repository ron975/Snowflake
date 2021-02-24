﻿using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snowflake.Configuration.Generators
{
    internal class ConfigurationTypes
    {
#nullable disable
        public ConfigurationTypes(Compilation compilation)
        {
            this.ConfigurationSectionAttribute = compilation.GetTypeByMetadataName("Snowflake.Configuration.Attributes.ConfigurationSectionAttribute");
            this.ConfigurationOptionAttribute = compilation.GetTypeByMetadataName("Snowflake.Configuration.Attributes.ConfigurationOptionAttribute");
            this.InputOptionAttribute = compilation.GetTypeByMetadataName("Snowflake.Configuration.Input.InputOptionAttribute");

            this.IConfigurationSection = compilation.GetTypeByMetadataName("Snowflake.Configuration.IConfigurationSection");
            this.IConfigurationSectionGeneric = compilation.GetTypeByMetadataName("Snowflake.Configuration.IConfigurationSection`1");
            this.ConfigurationGenerationInstanceAttribute = compilation.GetTypeByMetadataName("Snowflake.Configuration.Generators.ConfigurationGenerationInstanceAttribute");
            this.SelectionOptionAttribute = compilation.GetTypeByMetadataName("Snowflake.Configuration.Attributes.SelectionOptionAttribute");

            this.ConfigurationTargetAttribute = compilation.GetTypeByMetadataName("Snowflake.Configuration.Attributes.ConfigurationTargetAttribute");
            this.ConfigurationTargetMemberAttribute = compilation.GetTypeByMetadataName("Snowflake.Configuration.Attributes.ConfigurationTargetMemberAttribute");

            this.IConfigurationCollection = compilation.GetTypeByMetadataName("Snowflake.Configuration.IConfigurationCollection");
            this.IConfigurationCollectionGeneric = compilation.GetTypeByMetadataName("Snowflake.Configuration.IConfigurationCollection`1");


            this.DeviceCapability = compilation.GetTypeByMetadataName("Snowflake.Input.Device.DeviceCapability");
            this.System_Guid = compilation.GetTypeByMetadataName("System.Guid");
        }

        public bool AllAvailable()
        {
            return this.ConfigurationSectionAttribute != null
                   && this.ConfigurationOptionAttribute != null
                   && this.InputOptionAttribute != null
                   && this.IConfigurationSection != null
                   && this.IConfigurationSectionGeneric != null
                   && this.ConfigurationGenerationInstanceAttribute != null
                   && this.SelectionOptionAttribute != null
                   && this.ConfigurationTargetAttribute != null
                   && this.ConfigurationTargetMemberAttribute != null
                   && this.IConfigurationCollection != null
                   && this.IConfigurationCollectionGeneric != null
                   && this.DeviceCapability != null
                   && this.System_Guid != null;
        }

        public bool CheckContext(GeneratorExecutionContext context, ref bool errorOccured)
        {
            if (this.AllAvailable())
                return true;
            context.ReportError(DiagnosticError.FrameworkNotFound,
                            "Snowflake Framework Not Found",
                            $"Required Snowflake framework types were not found.",
                            Location.None, ref errorOccured);
            return false;
        }

#nullable enable
        public INamedTypeSymbol ConfigurationSectionAttribute { get; }
        public INamedTypeSymbol ConfigurationOptionAttribute { get; }
        public INamedTypeSymbol InputOptionAttribute { get; }
        public INamedTypeSymbol IConfigurationSection { get; }
        public INamedTypeSymbol IConfigurationSectionGeneric { get; }
        public INamedTypeSymbol ConfigurationGenerationInstanceAttribute { get; }
        public INamedTypeSymbol SelectionOptionAttribute { get; }
        public INamedTypeSymbol ConfigurationTargetAttribute { get; }
        public INamedTypeSymbol ConfigurationTargetMemberAttribute { get; }
        public INamedTypeSymbol IConfigurationCollection { get; }
        public INamedTypeSymbol IConfigurationCollectionGeneric { get; }
        public INamedTypeSymbol DeviceCapability { get; }
        public INamedTypeSymbol System_Guid { get; }
    }
}
