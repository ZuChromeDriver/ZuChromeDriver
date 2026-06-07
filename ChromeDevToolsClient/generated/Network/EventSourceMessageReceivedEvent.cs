namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when EventSource message is received.
    /// </summary>
    public sealed class EventSourceMessageReceivedEvent : IEvent
    {
        /// <summary>
        /// Request identifier.
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
        /// <summary>
        /// Timestamp.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public double Timestamp
        {
            get;
            set;
        }
        /// <summary>
        /// Message type.
        /// </summary>
        [JsonPropertyName("eventName")]
        public string EventName
        {
            get;
            set;
        }
        /// <summary>
        /// Message identifier.
        /// </summary>
        [JsonPropertyName("eventId")]
        public string EventId
        {
            get;
            set;
        }
        /// <summary>
        /// Message content.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data
        {
            get;
            set;
        }
    }
}