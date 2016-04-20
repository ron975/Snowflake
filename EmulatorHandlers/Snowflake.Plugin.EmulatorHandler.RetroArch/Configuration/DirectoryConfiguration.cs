using Snowflake.Configuration;
using Snowflake.Configuration.Attributes;

//autogenerated using generate_retroarch.py
namespace Snowflake.Plugin.EmulatorHandler.RetroArch.Configuration
{
    public class DirectoryConfiguration : ConfigurationSection
    {

        [ConfigurationOption("assets_directory", DisplayName = "Assets Directory", FilePath = true, Private = true)]
        public string AssetsDirectory { get; set; } = "default";

        [ConfigurationOption("audio_filter_dir", DisplayName = "Audio Filter Dir", FilePath = true, Private = true)]
        public string AudioFilterDir { get; set; } = "default";

        [ConfigurationOption("bundle_assets_dst_path", DisplayName = "Bundle Assets Dst Path", FilePath = true, Private = true)]
        public string BundleAssetsDstPath { get; set; } = "";

        [ConfigurationOption("bundle_assets_dst_path_subdir", DisplayName = "Bundle Assets Dst Path Subdir", FilePath = true, Private = true)]
        public string BundleAssetsDstPathSubdir { get; set; } = "";

        [ConfigurationOption("bundle_assets_src_path", DisplayName = "Bundle Assets Src Path", FilePath = true, Private = true)]
        public string BundleAssetsSrcPath { get; set; } = "";

        [ConfigurationOption("cache_directory", DisplayName = "Cache Directory", FilePath = true, Private = true)]
        public string CacheDirectory { get; set; } = "";

        [ConfigurationOption("cheat_database_path", DisplayName = "Cheat Database Path", FilePath = true, Private = true)]
        public string CheatDatabasePath { get; set; } = "";

        [ConfigurationOption("content_database_path", DisplayName = "Content Database Path", FilePath = true, Private = true)]
        public string ContentDatabasePath { get; set; } = "";

        [ConfigurationOption("content_history_dir", DisplayName = "Content History Dir", FilePath = true, Private = true)]
        public string ContentHistoryDir { get; set; } = "";

        [ConfigurationOption("content_history_path", DisplayName = "Content History Path", FilePath = true, Private = true)]
        public string ContentHistoryPath { get; set; } = ":\\content_history.lpl";

        [ConfigurationOption("core_assets_directory", DisplayName = "Core Assets Directory", FilePath = true, Private = true)]
        public string CoreAssetsDirectory { get; set; } = "default";

        [ConfigurationOption("core_options_path", DisplayName = "Core Options Path", FilePath = true, Private = true)]
        public string CoreOptionsPath { get; set; } = "";

        [ConfigurationOption("cursor_directory", DisplayName = "Cursor Directory", FilePath = true, Private = true)]
        public string CursorDirectory { get; set; } = "";

        [ConfigurationOption("dynamic_wallpapers_directory", DisplayName = "Dynamic Wallpapers Directory", FilePath = true, Private = true)]
        public string DynamicWallpapersDirectory { get; set; } = "default";

        [ConfigurationOption("input_remapping_directory", DisplayName = "Input Remapping Directory", FilePath = true, Private = true)]
        public string InputRemappingDirectory { get; set; } = "";

        [ConfigurationOption("joypad_autoconfig_dir", DisplayName = "Joypad Autoconfig Dir", FilePath = true, Private = true)]
        public string JoypadAutoconfigDir { get; set; } = "";

        [ConfigurationOption("libretro_directory", DisplayName = "Libretro Directory", FilePath = true, Private = true)]
        public string LibretroDirectory { get; set; } = "";

        [ConfigurationOption("libretro_info_path", DisplayName = "Libretro Info Path", FilePath = true, Private = true)]
        public string LibretroInfoPath { get; set; } = "";

        [ConfigurationOption("osk_overlay_directory", DisplayName = "Osk Overlay Directory", FilePath = true, Private = true)]
        public string OskOverlayDirectory { get; set; } = "default";

        [ConfigurationOption("overlay_directory", DisplayName = "Overlay Directory", FilePath = true, Private = true)]
        public string OverlayDirectory { get; set; } = "default";

        [ConfigurationOption("playlist_directory", DisplayName = "Playlist Directory", FilePath = true, Private = true)]
        public string PlaylistDirectory { get; set; } = "default";

        [ConfigurationOption("recording_config_directory", DisplayName = "Recording Config Directory", FilePath = true, Private = true)]
        public string RecordingConfigDirectory { get; set; } = "";

        [ConfigurationOption("recording_output_directory", DisplayName = "Recording Output Directory", FilePath = true, Private = true)]
        public string RecordingOutputDirectory { get; set; } = "";

        [ConfigurationOption("resampler_directory", DisplayName = "Resampler Directory", FilePath = true, Private = true)]
        public string ResamplerDirectory { get; set; } = "";

        [ConfigurationOption("rgui_browser_directory", DisplayName = "Rgui Browser Directory", FilePath = true, Private = true)]
        public string RguiBrowserDirectory { get; set; } = "default";

        [ConfigurationOption("rgui_config_directory", DisplayName = "Rgui Config Directory", FilePath = true, Private = true)]
        public string RguiConfigDirectory { get; set; } = "default";

        [ConfigurationOption("screenshot_directory", DisplayName = "Screenshot Directory", FilePath = true, Private = true)]
        public string ScreenshotDirectory { get; set; } = "default";

        [ConfigurationOption("system_directory", DisplayName = "System Directory", FilePath = true, Private = true)]
        public string SystemDirectory { get; set; } = "default";

        [ConfigurationOption("savefile_directory", DisplayName = "Savefile Directory")]
        public string SavefileDirectory { get; set; } = "default";

        [ConfigurationOption("thumbnails_directory", DisplayName = "Thumbnails Directory", FilePath = true, Private = true)]
        public string ThumbnailsDirectory { get; set; } = "default";

        [ConfigurationOption("video_filter_dir", DisplayName = "Video Filter Dir", FilePath = true, Private = true)]
        public string VideoFilterDir { get; set; } = "default";

        [ConfigurationOption("video_font_path", DisplayName = "Video Font Path", FilePath = true, Private = true)]
        public string VideoFontPath { get; set; } = "";

        [ConfigurationOption("video_shader_dir", DisplayName = "Video Shader Dir", FilePath = true, Private = true)]
        public string VideoShaderDir { get; set; } = "default";
        [ConfigurationOption("savestate_directory", DisplayName = "Savestate Directory", FilePath = true, Private = true)]
        public string SavestateDirectory { get; set; } = "default";

        public DirectoryConfiguration() : base("directory", "Directory Options", "retroarch.cfg")
        {

        }

    }
}
