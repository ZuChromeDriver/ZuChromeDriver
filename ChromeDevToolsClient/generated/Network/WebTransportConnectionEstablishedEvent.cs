namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when WebTransport handshake is finished.
    /// </summary>
    public sealed class WebTransportConnectionEstablishedEvent : IEvent
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
        /// Timestamp.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public double Timestamp
        {
            get;
            set;
        }
    }
}