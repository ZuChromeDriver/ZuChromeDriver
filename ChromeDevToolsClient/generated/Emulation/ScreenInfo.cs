namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Screen information similar to the one returned by window.getScreenDetails() method,
    /// see https://w3c.github.io/window-management/#screendetailed.
    /// </summary>
    public sealed class ScreenInfo
    {
        /// <summary>
        /// Offset of the left edge of the screen.
        ///</summary>
        [JsonPropertyName("left")]
        public long Left
        {
            get;
            set;
        }
        /// <summary>
        /// Offset of the top edge of the screen.
        ///</summary>
        [JsonPropertyName("top")]
        public long Top
        {
            get;
            set;
        }
        /// <summary>
        /// Width of the screen.
        ///</summary>
        [JsonPropertyName("width")]
        public long Width
        {
            get;
            set;
        }
        /// <summary>
        /// Height of the screen.
        ///</summary>
        [JsonPropertyName("height")]
        public long Height
        {
            get;
            set;
        }
        /// <summary>
        /// Offset of the left edge of the available screen area.
        ///</summary>
        [JsonPropertyName("availLeft")]
        public long AvailLeft
        {
            get;
            set;
        }
        /// <summary>
        /// Offset of the top edge of the available screen area.
        ///</summary>
        [JsonPropertyName("availTop")]
        public long AvailTop
        {
            get;
            set;
        }
        /// <summary>
        /// Width of the available screen area.
        ///</summary>
        [JsonPropertyName("availWidth")]
        public long AvailWidth
        {
            get;
            set;
        }
        /// <summary>
        /// Height of the available screen area.
        ///</summary>
        [JsonPropertyName("availHeight")]
        public long AvailHeight
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the screen's device pixel ratio.
        ///</summary>
        [JsonPropertyName("devicePixelRatio")]
        public double DevicePixelRatio
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the screen's orientation.
        ///</summary>
        [JsonPropertyName("orientation")]
        public ScreenOrientation Orientation
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the screen's color depth in bits.
        ///</summary>
        [JsonPropertyName("colorDepth")]
        public long ColorDepth
        {
            get;
            set;
        }
        /// <summary>
        /// Indicates whether the device has multiple screens.
        ///</summary>
        [JsonPropertyName("isExtended")]
        public bool IsExtended
        {
            get;
            set;
        }
        /// <summary>
        /// Indicates whether the screen is internal to the device or external, attached to the device.
        ///</summary>
        [JsonPropertyName("isInternal")]
        public bool IsInternal
        {
            get;
            set;
        }
        /// <summary>
        /// Indicates whether the screen is set as the the operating system primary screen.
        ///</summary>
        [JsonPropertyName("isPrimary")]
        public bool IsPrimary
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the descriptive label for the screen.
        ///</summary>
        [JsonPropertyName("label")]
        public string Label
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the unique identifier of the screen.
        ///</summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
    }
}