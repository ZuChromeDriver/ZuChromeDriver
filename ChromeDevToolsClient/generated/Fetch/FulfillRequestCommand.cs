namespace Zu.ChromeDevTools.Fetch
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Provides response to the request.
    /// </summary>
    public sealed class FulfillRequestCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Fetch.fulfillRequest";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// An id the client received in requestPaused event.
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
        /// <summary>
        /// An HTTP response code.
        /// </summary>
        [JsonPropertyName("responseCode")]
        public long ResponseCode
        {
            get;
            set;
        }
        /// <summary>
        /// Response headers.
        /// </summary>
        [JsonPropertyName("responseHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public HeaderEntry[] ResponseHeaders
        {
            get;
            set;
        }
        /// <summary>
        /// Alternative way of specifying response headers as a \0-separated
        /// series of name: value pairs. Prefer the above method unless you
        /// need to represent some non-UTF8 values that can't be transmitted
        /// over the protocol as text. (Encoded as a base64 string when passed over JSON)
        /// </summary>
        [JsonPropertyName("binaryResponseHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BinaryResponseHeaders
        {
            get;
            set;
        }
        /// <summary>
        /// A response body. If absent, original response body will be used if
        /// the request is intercepted at the response stage and empty body
        /// will be used if the request is intercepted at the request stage. (Encoded as a base64 string when passed over JSON)
        /// </summary>
        [JsonPropertyName("body")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Body
        {
            get;
            set;
        }
        /// <summary>
        /// A textual representation of responseCode.
        /// If absent, a standard phrase matching responseCode is used.
        /// </summary>
        [JsonPropertyName("responsePhrase")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ResponsePhrase
        {
            get;
            set;
        }
    }

    public sealed class FulfillRequestCommandResponse : ICommandResponse<FulfillRequestCommand>
    {
    }
}