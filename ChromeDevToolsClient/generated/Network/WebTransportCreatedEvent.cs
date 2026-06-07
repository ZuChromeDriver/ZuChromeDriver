namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired upon WebTransport creation.
    /// </summary>
    public sealed class WebTransportCreatedEvent : IEvent
    {
        /// <summary>
        /// WebTransport identifier.
        /// </summary>
        [JsonPropertyName("transportId")]
        public string TransportId
        {
            get;
            set;
        }
        /// <summary>
        /// WebTransport request URL.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
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
        /// Request initiator.
        /// </summary>
        [JsonPropertyName("initiator")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Initiator Initiator
        {
            get;
            set;
        }
    }
}