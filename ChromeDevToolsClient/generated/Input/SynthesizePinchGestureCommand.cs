namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Synthesizes a pinch gesture over a time period by issuing appropriate touch events.
    /// </summary>
    public sealed class SynthesizePinchGestureCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Input.synthesizePinchGesture";
        
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
        /// Relative scale factor after zooming (>1.0 zooms in, <1.0 zooms out).
        /// </summary>
        [JsonPropertyName("scaleFactor")]
        public double ScaleFactor
        {
            get;
            set;
        }
        /// <summary>
        /// Relative pointer speed in pixels per second (default: 800).
        /// </summary>
        [JsonPropertyName("relativeSpeed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? RelativeSpeed
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

    public sealed class SynthesizePinchGestureCommandResponse : ICommandResponse<SynthesizePinchGestureCommand>
    {
    }
}