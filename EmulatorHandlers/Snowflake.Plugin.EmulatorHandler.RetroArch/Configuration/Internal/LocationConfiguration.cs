using Snowflake.Configuration;
using Snowflake.Configuration.Attributes;

//autogenerated using generate_retroarch.py
namespace Snowflake.Plugin.EmulatorHandler.RetroArch.Configuration.Internal
{
    public class LocationConfiguration : ConfigurationSection
    {
        /// <summary>
        /// Not applicable on Desktop devices
        /// </summary>
        [ConfigurationOption("location_allow", DisplayName = "Location Allow", Private = true)]
        public bool LocationAllow { get; set; } = false;
        
        //this can be enum but null is the only possible value.
        [ConfigurationOption("location_driver", DisplayName = "Location Driver", Private = true)]
        public string LocationDriver { get; set; } = "null";

        public LocationConfiguration() : base("location", "Location Options", "retroarch.cfg")
        {

        }

    }
}
