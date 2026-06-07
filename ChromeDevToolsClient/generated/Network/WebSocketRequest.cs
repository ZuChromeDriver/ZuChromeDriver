namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// WebSocket request data.
    /// </summary>
    public sealed class WebSocketRequest
    {
        /// <summary>
        /// HTTP request headers.
        ///</summary>
        [JsonPropertyName("headers")]
        public Headers Headers
        {
            get;
            set;
        }
    }
}