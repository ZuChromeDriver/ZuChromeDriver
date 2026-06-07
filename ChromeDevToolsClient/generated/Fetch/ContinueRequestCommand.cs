namespace Zu.ChromeDevTools.Fetch
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Continues the request, optionally modifying some of its parameters.
    /// </summary>
    public sealed class ContinueRequestCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Fetch.continueRequest";
        
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
        /// If set, the request url will be modified in a way that's not observable by page.
        /// </summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// If set, the request method is overridden.
        /// </summary>
        [JsonPropertyName("method")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Method
        {
            get;
            set;
        }
        /// <summary>
        /// If set, overrides the post data in the request. (Encoded as a base64 string when passed over JSON)
        /// </summary>
        [JsonPropertyName("postData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PostData
        {
            get;
            set;
        }
        /// <summary>
        /// If set, overrides the request headers. Note that the overrides do not
        /// extend to subsequent redirect hops, if a redirect happens. Another override
        /// may be applied to a different request produced by a redirect.
        /// </summary>
        [JsonPropertyName("headers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public HeaderEntry[] Headers
        {
            get;
            set;
        }
        /// <summary>
        /// If set, overrides response interception behavior for this request.
        /// </summary>
        [JsonPropertyName("interceptResponse")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? InterceptResponse
        {
            get;
            set;
        }
    }

    public sealed class ContinueRequestCommandResponse : ICommandResponse<ContinueRequestCommand>
    {
    }
}