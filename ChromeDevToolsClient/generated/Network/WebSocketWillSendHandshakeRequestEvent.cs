namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when WebSocket is about to initiate handshake.
    /// </summary>
    public sealed class WebSocketWillSendHandshakeRequestEvent : IEvent
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
        /// UTC Timestamp.
        /// </summary>
        [JsonPropertyName("wallTime")]
        public double WallTime
        {
            get;
            set;
        }
        /// <summary>
        /// WebSocket request data.
        /// </summary>
        [JsonPropertyName("request")]
        public WebSocketRequest Request
        {
            get;
            set;
        }
    }
}