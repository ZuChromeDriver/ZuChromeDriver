namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Overrides the values of device screen dimensions (window.screen.width, window.screen.height,
    /// window.innerWidth, window.innerHeight, and "device-width"/"device-height"-related CSS media
    /// query results).
    /// </summary>
    public sealed class SetDeviceMetricsOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.setDeviceMetricsOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Overriding width value in pixels (minimum 0, maximum 10000000). 0 disables the override.
        /// </summary>
        [JsonPropertyName("width")]
        public long Width
        {
            get;
            set;
        }
        /// <summary>
        /// Overriding height value in pixels (minimum 0, maximum 10000000). 0 disables the override.
        /// </summary>
        [JsonPropertyName("height")]
        public long Height
        {
            get;
            set;
        }
        /// <summary>
        /// Overriding device scale factor value. 0 disables the override.
        /// </summary>
        [JsonPropertyName("deviceScaleFactor")]
        public double DeviceScaleFactor
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to emulate mobile device. This includes viewport meta tag, overlay scrollbars, text
        /// autosizing and more.
        /// </summary>
        [JsonPropertyName("mobile")]
        public bool Mobile
        {
            get;
            set;
        }
        /// <summary>
        /// Scale to apply to resulting view image.
        /// </summary>
        [JsonPropertyName("scale")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Scale
        {
            get;
            set;
        }
        /// <summary>
        /// Overriding screen width value in pixels (minimum 0, maximum 10000000).
        /// </summary>
        [JsonPropertyName("screenWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ScreenWidth
        {
            get;
            set;
        }
        /// <summary>
        /// Overriding screen height value in pixels (minimum 0, maximum 10000000).
        /// </summary>
        [JsonPropertyName("screenHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ScreenHeight
        {
            get;
            set;
        }
        /// <summary>
        /// Overriding view X position on screen in pixels (minimum 0, maximum 10000000).
        /// </summary>
        [JsonPropertyName("positionX")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? PositionX
        {
            get;
            set;
        }
        /// <summary>
        /// Overriding view Y position on screen in pixels (minimum 0, maximum 10000000).
        /// </summary>
        [JsonPropertyName("positionY")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? PositionY
        {
            get;
            set;
        }
        /// <summary>
        /// Do not set visible view size, rely upon explicit setVisibleSize call.
        /// </summary>
        [JsonPropertyName("dontSetVisibleSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? DontSetVisibleSize
        {
            get;
            set;
        }
        /// <summary>
        /// Screen orientation override.
        /// </summary>
        [JsonPropertyName("screenOrientation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Emulation.ScreenOrientation ScreenOrientation
        {
            get;
            set;
        }
        /// <summary>
        /// The viewport dimensions and scale. If not set, the override is cleared.
        /// </summary>
        [JsonPropertyName("viewport")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Viewport Viewport
        {
            get;
            set;
        }
    }

    public sealed class SetDeviceMetricsOverrideCommandResponse : ICommandResponse<SetDeviceMetricsOverrideCommand>
    {
    }
}