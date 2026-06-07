namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Synthesizes a tap gesture over a time period by issuing appropriate touch events.
    /// </summary>
    public sealed class SynthesizeTapGestureCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Input.synthesizeTapGesture";
        
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
        /// Duration between touchdown and touchup events in ms (default: 50).
        /// </summary>
        [JsonPropertyName("duration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Duration
        {
            get;
            set;
        }
        /// <summary>
        /// Number of times to perform the tap (e.g. 2 for double tap, default: 1).
        /// </summary>
        [JsonPropertyName("tapCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? TapCount
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
    }

    public sealed class SynthesizeTapGestureCommandResponse : ICommandResponse<SynthesizeTapGestureCommand>
    {
    }
}