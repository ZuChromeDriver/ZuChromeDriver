namespace Zu.ChromeDevTools.SystemInfo
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Provides information about the GPU(s) on the system.
    /// </summary>
    public sealed class GPUInfo
    {
        /// <summary>
        /// The graphics devices on the system. Element 0 is the primary GPU.
        ///</summary>
        [JsonPropertyName("devices")]
        public GPUDevice[] Devices
        {
            get;
            set;
        }
        /// <summary>
        /// An optional dictionary of additional GPU related attributes.
        ///</summary>
        [JsonPropertyName("auxAttributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object AuxAttributes
        {
            get;
            set;
        }
        /// <summary>
        /// An optional dictionary of graphics features and their status.
        ///</summary>
        [JsonPropertyName("featureStatus")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object FeatureStatus
        {
            get;
            set;
        }
        /// <summary>
        /// An optional array of GPU driver bug workarounds.
        ///</summary>
        [JsonPropertyName("driverBugWorkarounds")]
        public string[] DriverBugWorkarounds
        {
            get;
            set;
        }
        /// <summary>
        /// Supported accelerated video decoding capabilities.
        ///</summary>
        [JsonPropertyName("videoDecoding")]
        public VideoDecodeAcceleratorCapability[] VideoDecoding
        {
            get;
            set;
        }
        /// <summary>
        /// Supported accelerated video encoding capabilities.
        ///</summary>
        [JsonPropertyName("videoEncoding")]
        public VideoEncodeAcceleratorCapability[] VideoEncoding
        {
            get;
            set;
        }
    }
}