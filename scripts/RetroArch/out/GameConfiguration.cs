using Snowflake.Configuration;
using Snowflake.Configuration.Attributes;

//autogenerated using generate_retroarch.py
namespace Snowflake.Plugin.EmulatorAdapter.RetroArch.Configuration.Internal
{
   [ConfigurationSection("game", "Game Options")]
 public interface GameConfiguration : IConfigurationSection<GameConfiguration>
    {
        [ConfigurationOption("game_specific_options",false, DisplayName = "Game Specific Options", Private = true)]
        bool GameSpecificOptions { get; set; }

        [ConfigurationOption("bps_pref",false, DisplayName = "Prefer BPS Patching", Private = true)]
        bool BpsPref { get; set; }

        [ConfigurationOption("ips_pref",false, DisplayName = "Prefer IPS Patching", Private = true)]
        bool IpsPref { get; set; }

        [ConfigurationOption("ups_pref",false, DisplayName = "Prefer UPS Patching", Private = true)]
        bool UpsPref { get; set; }

    }
}

