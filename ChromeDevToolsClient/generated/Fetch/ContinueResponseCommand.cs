namespace Zu.ChromeDevTools.Fetch
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Continues loading of the paused response, optionally modifying the
    /// response headers. If either responseCode or headers are modified, all of them
    /// must be present.
    /// </summary>
    public sealed class ContinueResponseCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Fetch.continueResponse";
        
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
        /// An HTTP response code. If absent, original response code will be used.
        /// </summary>
        [JsonPropertyName("responseCode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ResponseCode
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
        /// <summary>
        /// Response headers. If absent, original response headers will be used.
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
    }

    public sealed class ContinueResponseCommandResponse : ICommandResponse<ContinueResponseCommand>
    {
    }
}