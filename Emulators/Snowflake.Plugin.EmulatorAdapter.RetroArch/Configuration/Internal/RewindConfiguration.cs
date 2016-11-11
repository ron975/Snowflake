using Snowflake.Configuration;
using Snowflake.Configuration.Attributes;

//autogenerated using generate_retroarch.py

namespace Snowflake.Plugin.EmulatorAdapter.RetroArch.Configuration.Internal
{
    [ConfigurationSection("rewind", "Rewind Options")]
    public interface RewindConfiguration : IConfigurationSection<RewindConfiguration>
    {
        [ConfigurationOption("rewind_enable", false, DisplayName = "Enable Rewind", Private = true)]
        bool RewindEnable { get; set; }

        [ConfigurationOption("rewind_granularity", 1, DisplayName = "Rewind Granularity", Private = true)]
        int RewindGranularity { get; set; }
    }
}