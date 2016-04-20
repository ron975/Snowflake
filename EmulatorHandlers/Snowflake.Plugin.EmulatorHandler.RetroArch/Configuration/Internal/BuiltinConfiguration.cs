using Snowflake.Configuration;
using Snowflake.Configuration.Attributes;

//autogenerated using generate_retroarch.py
namespace Snowflake.Plugin.EmulatorHandler.RetroArch.Configuration.Internal
{
    public class BuiltinConfiguration : ConfigurationSection
    {
       [ConfigurationOption("builtin_imageviewer_enable", DisplayName = "Builtin Imageviewer Enable", Private = true)]
       public bool BuiltinImageviewerEnable { get; set; } = true;
       [ConfigurationOption("builtin_mediaplayer_enable", DisplayName = "Builtin Mediaplayer Enable", Private = true)]
       public bool BuiltinMediaplayerEnable { get; set; } = true;

       public BuiltinConfiguration() : base ("builtin", "Builtin Options", "retroarch.cfg")
       {

       }
       
     }
}
