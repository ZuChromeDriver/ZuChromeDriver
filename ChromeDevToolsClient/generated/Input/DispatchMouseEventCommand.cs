namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Dispatches a mouse event to the page.
    /// </summary>
    public sealed class DispatchMouseEventCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Input.dispatchMouseEvent";
        
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
        /// X coordinate of the event relative to the main frame's viewport in CSS pixels.
        /// </summary>
        [JsonPropertyName("x")]
        public double X
        {
            get;
            set;
        }
        /// <summary>
        /// Y coordinate of the event relative to the main frame's viewport in CSS pixels. 0 refers to
        /// the top of the viewport and Y increases as it proceeds towards the bottom of the viewport.
        /// </summary>
        [JsonPropertyName("y")]
        public double Y
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
        /// Time at which the event occurred.
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Timestamp
        {
            get;
            set;
        }
        /// <summary>
        /// Mouse button (default: "none").
        /// </summary>
        [JsonPropertyName("button")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public MouseButton? Button
        {
            get;
            set;
        }
        /// <summary>
        /// A number indicating which buttons are pressed on the mouse when a mouse event is triggered.
        /// Left=1, Right=2, Middle=4, Back=8, Forward=16, None=0.
        /// </summary>
        [JsonPropertyName("buttons")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Buttons
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
        /// <summary>
        /// The normalized pressure, which has a range of [0,1] (default: 0).
        /// </summary>
        [JsonPropertyName("force")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Force
        {
            get;
            set;
        }
        /// <summary>
        /// The normalized tangential pressure, which has a range of [-1,1] (default: 0).
        /// </summary>
        [JsonPropertyName("tangentialPressure")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? TangentialPressure
        {
            get;
            set;
        }
        /// <summary>
        /// The plane angle between the Y-Z plane and the plane containing both the stylus axis and the Y axis, in degrees of the range [-90,90], a positive tiltX is to the right (default: 0).
        /// </summary>
        [JsonPropertyName("tiltX")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? TiltX
        {
            get;
            set;
        }
        /// <summary>
        /// The plane angle between the X-Z plane and the plane containing both the stylus axis and the X axis, in degrees of the range [-90,90], a positive tiltY is towards the user (default: 0).
        /// </summary>
        [JsonPropertyName("tiltY")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? TiltY
        {
            get;
            set;
        }
        /// <summary>
        /// The clockwise rotation of a pen stylus around its own major axis, in degrees in the range [0,359] (default: 0).
        /// </summary>
        [JsonPropertyName("twist")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Twist
        {
            get;
            set;
        }
        /// <summary>
        /// X delta in CSS pixels for mouse wheel event (default: 0).
        /// </summary>
        [JsonPropertyName("deltaX")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? DeltaX
        {
            get;
            set;
        }
        /// <summary>
        /// Y delta in CSS pixels for mouse wheel event (default: 0).
        /// </summary>
        [JsonPropertyName("deltaY")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? DeltaY
        {
            get;
            set;
        }
        /// <summary>
        /// Pointer type (default: "mouse").
        /// </summary>
        [JsonPropertyName("pointerType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PointerType
        {
            get;
            set;
        }
    }

    public sealed class DispatchMouseEventCommandResponse : ICommandResponse<DispatchMouseEventCommand>
    {
    }
}