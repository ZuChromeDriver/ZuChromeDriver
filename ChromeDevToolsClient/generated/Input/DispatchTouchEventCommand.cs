namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Dispatches a touch event to the page.
    /// </summary>
    public sealed class DispatchTouchEventCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Input.dispatchTouchEvent";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Type of the touch event. TouchEnd and TouchCancel must not contain any touch points, while
        /// TouchStart and TouchMove must contains at least one.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// Active touch points on the touch device. One event per any changed point (compared to
        /// previous touch event in a sequence) is generated, emulating pressing/moving/releasing points
        /// one by one.
        /// </summary>
        [JsonPropertyName("touchPoints")]
        public TouchPoint[] TouchPoints
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
    }

    public sealed class DispatchTouchEventCommandResponse : ICommandResponse<DispatchTouchEventCommand>
    {
    }
}