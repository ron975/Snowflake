using Snowflake.Configuration;

// autogenerated using generate_retroarch.py
namespace Snowflake.Plugin.Emulators.RetroArch.Configuration.Internal
{
    [ConfigurationSection("ui", "UI Options")]
    public partial interface UiConfiguration
    {
        [ConfigurationOption("ui_companion_enable", false, DisplayName = "Ui Companion Enable")]
        bool UiCompanionEnable { get; set; }

        [ConfigurationOption("ui_companion_start_on_boot", true, DisplayName = "Ui Companion Start On Boot")]
        bool UiCompanionStartOnBoot { get; set; }

        [ConfigurationOption("ui_menubar_enable", false, DisplayName = "Ui Menubar Enable")]
        bool UiMenubarEnable { get; set; }
    }
}
