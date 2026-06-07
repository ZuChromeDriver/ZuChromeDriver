namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Emulates touch event from the mouse event parameters.
    /// </summary>
    public sealed class EmulateTouchFromMouseEventCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Input.emulateTouchFromMouseEvent";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Type of the mouse event.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// X coordinate of the mouse pointer in DIP.
        /// </summary>
        [JsonPropertyName("x")]
        public long X
        {
            get;
            set;
        }
        /// <summary>
        /// Y coordinate of the mouse pointer in DIP.
        /// </summary>
        [JsonPropertyName("y")]
        public long Y
        {
            get;
            set;
        }
        /// <summary>
        /// Mouse button. Only "none", "left", "right" are supported.
        /// </summary>
        [JsonPropertyName("button")]
        public MouseButton Button
        {
            get;
            set;
        }
        /// <summary>
        /// Time at which the event occurred (default: current time).
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Timestamp
        {
            get;
            set;
        }
        /// <summary>
        /// X delta in DIP for mouse wheel event (default: 0).
        /// </summary>
        [JsonPropertyName("deltaX")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? DeltaX
        {
            get;
            set;
        }
        /// <summary>
        /// Y delta in DIP for mouse wheel event (default: 0).
        /// </summary>
        [JsonPropertyName("deltaY")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? DeltaY
        {
            get;
            set;
        }
        /// <summary>
        /// Bit field representing pressed modifier keys. Alt=1, Ctrl=2, Meta/Command=4, Shift=8
        /// (default: 0).
        /// </summary>
        [JsonPropertyName("modifiers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Modifiers
        {
            get;
            set;
        }
        /// <summary>
        /// Number of times the mouse button was clicked (default: 0).
        /// </summary>
        [JsonPropertyName("clickCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ClickCount
        {
            get;
            set;
        }
    }

    public sealed class EmulateTouchFromMouseEventCommandResponse : ICommandResponse<EmulateTouchFromMouseEventCommand>
    {
    }
}