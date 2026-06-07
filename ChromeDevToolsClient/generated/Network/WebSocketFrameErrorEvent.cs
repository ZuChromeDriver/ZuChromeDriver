namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when WebSocket message error occurs.
    /// </summary>
    public sealed class WebSocketFrameErrorEvent : IEvent
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
        /// WebSocket error message.
        /// </summary>
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage
        {
            get;
            set;
        }
    }
}