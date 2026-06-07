namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Screencast frame metadata.
    /// </summary>
    public sealed class ScreencastFrameMetadata
    {
        /// <summary>
        /// Top offset in DIP.
        ///</summary>
        [JsonPropertyName("offsetTop")]
        public double OffsetTop
        {
            get;
            set;
        }
        /// <summary>
        /// Page scale factor.
        ///</summary>
        [JsonPropertyName("pageScaleFactor")]
        public double PageScaleFactor
        {
            get;
            set;
        }
        /// <summary>
        /// Device screen width in DIP.
        ///</summary>
        [JsonPropertyName("deviceWidth")]
        public double DeviceWidth
        {
            get;
            set;
        }
        /// <summary>
        /// Device screen height in DIP.
        ///</summary>
        [JsonPropertyName("deviceHeight")]
        public double DeviceHeight
        {
            get;
            set;
        }
        /// <summary>
        /// Position of horizontal scroll in CSS pixels.
        ///</summary>
        [JsonPropertyName("scrollOffsetX")]
        public double ScrollOffsetX
        {
            get;
            set;
        }
        /// <summary>
        /// Position of vertical scroll in CSS pixels.
        ///</summary>
        [JsonPropertyName("scrollOffsetY")]
        public double ScrollOffsetY
        {
            get;
            set;
        }
        /// <summary>
        /// Frame swap timestamp.
        ///</summary>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Timestamp
        {
            get;
            set;
        }
    }
}