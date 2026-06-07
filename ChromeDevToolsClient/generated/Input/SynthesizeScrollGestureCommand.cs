namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Synthesizes a scroll gesture over a time period by issuing appropriate touch events.
    /// </summary>
    public sealed class SynthesizeScrollGestureCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Input.synthesizeScrollGesture";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// X coordinate of the start of the gesture in CSS pixels.
        /// </summary>
        [JsonPropertyName("x")]
        public double X
        {
            get;
            set;
        }
        /// <summary>
        /// Y coordinate of the start of the gesture in CSS pixels.
        /// </summary>
        [JsonPropertyName("y")]
        public double Y
        {
            get;
            set;
        }
        /// <summary>
        /// The distance to scroll along the X axis (positive to scroll left).
        /// </summary>
        [JsonPropertyName("xDistance")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? XDistance
        {
            get;
            set;
        }
        /// <summary>
        /// The distance to scroll along the Y axis (positive to scroll up).
        /// </summary>
        [JsonPropertyName("yDistance")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? YDistance
        {
            get;
            set;
        }
        /// <summary>
        /// The number of additional pixels to scroll back along the X axis, in addition to the given
        /// distance.
        /// </summary>
        [JsonPropertyName("xOverscroll")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? XOverscroll
        {
            get;
            set;
        }
        /// <summary>
        /// The number of additional pixels to scroll back along the Y axis, in addition to the given
        /// distance.
        /// </summary>
        [JsonPropertyName("yOverscroll")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? YOverscroll
        {
            get;
            set;
        }
        /// <summary>
        /// Prevent fling (default: true).
        /// </summary>
        [JsonPropertyName("preventFling")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? PreventFling
        {
            get;
            set;
        }
        /// <summary>
        /// Swipe speed in pixels per second (default: 800).
        /// </summary>
        [JsonPropertyName("speed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Speed
        {
            get;
            set;
        }
        /// <summary>
        /// Which type of input events to be generated (default: 'default', which queries the platform
        /// for the preferred input type).
        /// </summary>
        [JsonPropertyName("gestureSourceType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public GestureSourceType? GestureSourceType
        {
            get;
            set;
        }
        /// <summary>
        /// The number of times to repeat the gesture (default: 0).
        /// </summary>
        [JsonPropertyName("repeatCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? RepeatCount
        {
            get;
            set;
        }
        /// <summary>
        /// The number of milliseconds delay between each repeat. (default: 250).
        /// </summary>
        [JsonPropertyName("repeatDelayMs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? RepeatDelayMs
        {
            get;
            set;
        }
        /// <summary>
        /// The name of the interaction markers to generate, if not empty (default: "").
        /// </summary>
        [JsonPropertyName("interactionMarkerName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string InteractionMarkerName
        {
            get;
            set;
        }
    }

    public sealed class SynthesizeScrollGestureCommandResponse : ICommandResponse<SynthesizeScrollGestureCommand>
    {
    }
}