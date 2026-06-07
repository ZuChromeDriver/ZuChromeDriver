namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// WebSocket response data.
    /// </summary>
    public sealed class WebSocketResponse
    {
        /// <summary>
        /// HTTP response status code.
        ///</summary>
        [JsonPropertyName("status")]
        public long Status
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP response status text.
        ///</summary>
        [JsonPropertyName("statusText")]
        public string StatusText
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP response headers.
        ///</summary>
        [JsonPropertyName("headers")]
        public Headers Headers
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP response headers text.
        ///</summary>
        [JsonPropertyName("headersText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string HeadersText
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP request headers.
        ///</summary>
        [JsonPropertyName("requestHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Headers RequestHeaders
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP request headers text.
        ///</summary>
        [JsonPropertyName("requestHeadersText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RequestHeadersText
        {
            get;
            set;
        }
    }
}