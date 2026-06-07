namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Updates specified screen parameters. Only supported in headless mode.
    /// </summary>
    public sealed class UpdateScreenCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.updateScreen";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Target screen identifier.
        /// </summary>
        [JsonPropertyName("screenId")]
        public string ScreenId
        {
            get;
            set;
        }
        /// <summary>
        /// Offset of the left edge of the screen in pixels.
        /// </summary>
        [JsonPropertyName("left")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Left
        {
            get;
            set;
        }
        /// <summary>
        /// Offset of the top edge of the screen in pixels.
        /// </summary>
        [JsonPropertyName("top")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Top
        {
            get;
            set;
        }
        /// <summary>
        /// The width of the screen in pixels.
        /// </summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Width
        {
            get;
            set;
        }
        /// <summary>
        /// The height of the screen in pixels.
        /// </summary>
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Height
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the screen's work area.
        /// </summary>
        [JsonPropertyName("workAreaInsets")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public WorkAreaInsets WorkAreaInsets
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the screen's device pixel ratio.
        /// </summary>
        [JsonPropertyName("devicePixelRatio")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? DevicePixelRatio
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the screen's rotation angle. Available values are 0, 90, 180 and 270.
        /// </summary>
        [JsonPropertyName("rotation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Rotation
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the screen's color depth in bits.
        /// </summary>
        [JsonPropertyName("colorDepth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ColorDepth
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies the descriptive label for the screen.
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

    public sealed class UpdateScreenCommandResponse : ICommandResponse<UpdateScreenCommand>
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