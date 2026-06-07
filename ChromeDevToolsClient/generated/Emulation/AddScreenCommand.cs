namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Add a new screen to the device. Only supported in headless mode.
    /// </summary>
    public sealed class AddScreenCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.addScreen";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Offset of the left edge of the screen in pixels.
        /// </summary>
        [JsonPropertyName("left")]
        public long Left
        {
            get;
            set;
        }
        /// <summary>
        /// Offset of the top edge of the screen in pixels.
        /// </summary>
        [JsonPropertyName("top")]
        public long Top
        {
            get;
            set;
        }
        /// <summary>
        /// The width of the screen in pixels.
        /// </summary>
        [JsonPropertyName("width")]
        public long Width
        {
            get;
            set;
        }
        /// <summary>
        /// The height of the screen in pixels.
        /// </summary>
        [JsonPropertyName("height")]
        public long Height
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the screen's work area. Default is entire screen.
        /// </summary>
        [JsonPropertyName("workAreaInsets")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public WorkAreaInsets WorkAreaInsets
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the screen's device pixel ratio. Default is 1.
        /// </summary>
        [JsonPropertyName("devicePixelRatio")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? DevicePixelRatio
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the screen's rotation angle. Available values are 0, 90, 180 and 270. Default is 0.
        /// </summary>
        [JsonPropertyName("rotation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Rotation
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the screen's color depth in bits. Default is 24.
        /// </summary>
        [JsonPropertyName("colorDepth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ColorDepth
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the descriptive label for the screen. Default is none.
        /// </summary>
        [JsonPropertyName("label")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Label
        {
            get;
            set;
        }
        /// <summary>
        /// Indicates whether the screen is internal to the device or external, attached to the device. Default is false.
        /// </summary>
        [JsonPropertyName("isInternal")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsInternal
        {
            get;
            set;
        }
    }

    public sealed class AddScreenCommandResponse : ICommandResponse<AddScreenCommand>
    {
        /// <summary>
        /// Gets or sets the screenInfo
        /// </summary>
        [JsonPropertyName("screenInfo")]
        public ScreenInfo ScreenInfo
        {
            get;
            set;
        }
    }
}