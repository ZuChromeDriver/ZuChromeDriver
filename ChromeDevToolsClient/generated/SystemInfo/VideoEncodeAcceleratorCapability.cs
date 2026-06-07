namespace Zu.ChromeDevTools.SystemInfo
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Describes a supported video encoding profile with its associated maximum
    /// resolution and maximum framerate.
    /// </summary>
    public sealed class VideoEncodeAcceleratorCapability
    {
        /// <summary>
        /// Video codec profile that is supported, e.g H264 Main.
        ///</summary>
        [JsonPropertyName("profile")]
        public string Profile
        {
            get;
            set;
        }
        /// <summary>
        /// Maximum video dimensions in pixels supported for this |profile|.
        ///</summary>
        [JsonPropertyName("maxResolution")]
        public Size MaxResolution
        {
            get;
            set;
        }
        /// <summary>
        /// Maximum encoding framerate in frames per second supported for this
        /// |profile|, as fraction's numerator and denominator, e.g. 24/1 fps,
        /// 24000/1001 fps, etc.
        ///</summary>
        [JsonPropertyName("maxFramerateNumerator")]
        public long MaxFramerateNumerator
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the maxFramerateDenominator
        /// </summary>
        [JsonPropertyName("maxFramerateDenominator")]
        public long MaxFramerateDenominator
        {
            get;
            set;
        }
    }
}