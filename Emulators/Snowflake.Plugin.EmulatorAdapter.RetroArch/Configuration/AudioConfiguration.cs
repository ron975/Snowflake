using Snowflake.Configuration;
using Snowflake.Configuration.Attributes;
using Snowflake.Plugin.EmulatorAdapter.RetroArch.Selections.AudioConfiguration;

//autogenerated using generate_retroarch.py
//checked

namespace Snowflake.Plugin.EmulatorAdapter.RetroArch.Configuration
{
    [ConfigurationSection("audio", "Audio Options")]
    public interface AudioConfiguration : IConfigurationSection<AudioConfiguration>
    {
        [ConfigurationOption("audio_block_frames", 0, DisplayName = "Block Frames", Private = true)]
        int AudioBlockFrames { get; set; }

        [ConfigurationOption("audio_device", "", DisplayName = "Audio Device", Private = true)]
        string AudioDevice { get; set; }

        [ConfigurationOption("audio_driver", AudioDriver.XAudio, DisplayName = "Audio Driver", Simple = true)]
        AudioDriver AudioDriver { get; set; }

        [ConfigurationOption("audio_dsp_plugin", "", DisplayName = "Audio DSP Plugin", Private = true)]
        string AudioDspPlugin { get; set; }

        [ConfigurationOption("audio_enable", true, DisplayName = "Audio Enable", Simple = true)]
        bool AudioEnable { get; set; }

        [ConfigurationOption("audio_filter_dir", "default", DisplayName = "Audio Filter Dir", IsPath = true)]
        string AudioFilterDir { get; set; }

        [ConfigurationOption("audio_latency", 64, DisplayName = "Audio Latency (ms)", Min = 8, Max = 504, Increment = 24
            )]
        int AudioLatency { get; set; }

        [ConfigurationOption("audio_max_timing_skew", 0.050000, DisplayName = "Audio Max Timing Skew", Max = 0.5,
            Increment = 0.01)]
        double AudioMaxTimingSkew { get; set; }

        [ConfigurationOption("audio_mute_enable", false, DisplayName = "Audio Mute Enable")]
        bool AudioMuteEnable { get; set; }

        [ConfigurationOption("audio_out_rate", 48000, DisplayName = "Audio Output Rate", Private = true)]
        int AudioOutRate { get; set; }

        [ConfigurationOption("audio_rate_control", true, DisplayName = "Audio Rate Control", Private = true)]
        bool AudioRateControl { get; set; }

        [ConfigurationOption("audio_rate_control_delta", 0.005000, DisplayName = "Audio Rate Control Delta",
            Increment = 0.001, Max = 1.0)]
        double AudioRateControlDelta { get; set; }

        [ConfigurationOption("audio_resampler", AudioResampler.Sinc, DisplayName = "Audio Resampler")]
        AudioResampler AudioResampler { get; set; }

        [ConfigurationOption("audio_sync", true, DisplayName = "Audio Sync Enable")]
        bool AudioSync { get; set; }

        [ConfigurationOption("audio_volume", 0.000000, DisplayName = "Audio Volume (db)", Increment = 1, Max = 10,
            Min = -80)]
        double AudioVolume { get; set; }
    }
}