namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Response to Network.requestIntercepted which either modifies the request to continue with any
    /// modifications, or blocks it, or completes it with the provided response bytes. If a network
    /// fetch occurs as a result which encounters a redirect an additional Network.requestIntercepted
    /// event will be sent with the same InterceptionId.
    /// Deprecated, use Fetch.continueRequest, Fetch.fulfillRequest and Fetch.failRequest instead.
    /// </summary>
    public sealed class ContinueInterceptedRequestCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.continueInterceptedRequest";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the interceptionId
        /// </summary>
        [JsonPropertyName("interceptionId")]
        public string InterceptionId
        {
            get;
            set;
        }
        /// <summary>
        /// If set this causes the request to fail with the given reason. Passing `Aborted` for requests
        /// marked with `isNavigationRequest` also cancels the navigation. Must not be set in response
        /// to an authChallenge.
        /// </summary>
        [JsonPropertyName("errorReason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ErrorReason? ErrorReason
        {
            get;
            set;
        }
        /// <summary>
        /// If set the requests completes using with the provided base64 encoded raw response, including
        /// HTTP status line and headers etc... Must not be set in response to an authChallenge. (Encoded as a base64 string when passed over JSON)
        /// </summary>
        [JsonPropertyName("rawResponse")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RawResponse
        {
            get;
            set;
        }
        /// <summary>
        /// If set the request url will be modified in a way that's not observable by page. Must not be
        /// set in response to an authChallenge.
        /// </summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// If set this allows the request method to be overridden. Must not be set in response to an
        /// authChallenge.
        /// </summary>
        [JsonPropertyName("method")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Method
        {
            get;
            set;
        }
        /// <summary>
        /// If set this allows postData to be set. Must not be set in response to an authChallenge.
        /// </summary>
        [JsonPropertyName("postData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PostData
        {
            get;
            set;
        }
        /// <summary>
        /// If set this allows the request headers to be changed. Must not be set in response to an
        /// authChallenge.
        /// </summary>
        [JsonPropertyName("headers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Headers Headers
        {
            get;
            set;
        }
        /// <summary>
        /// Response to a requestIntercepted with an authChallenge. Must not be set otherwise.
        /// </summary>
        [JsonPropertyName("authChallengeResponse")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AuthChallengeResponse AuthChallengeResponse
        {
            get;
            set;
        }
    }

    public sealed class ContinueInterceptedRequestCommandResponse : ICommandResponse<ContinueInterceptedRequestCommand>
    {
    }
}