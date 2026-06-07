namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when WebTransport is disposed.
    /// </summary>
    public sealed class WebTransportClosedEvent : IEvent
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