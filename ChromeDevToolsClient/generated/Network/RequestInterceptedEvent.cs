namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Details of an intercepted HTTP request, which must be either allowed, blocked, modified or
    /// mocked.
    /// Deprecated, use Fetch.requestPaused instead.
    /// </summary>
    public sealed class RequestInterceptedEvent : IEvent
    {
        /// <summary>
        /// Each request the page makes will have a unique id, however if any redirects are encountered
        /// while processing that fetch, they will be reported with the same id as the original fetch.
        /// Likewise if HTTP authentication is needed then the same fetch id will be used.
        /// </summary>
        [JsonPropertyName("interceptionId")]
        public string InterceptionId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the request
        /// </summary>
        [JsonPropertyName("request")]
        public Request Request
        {
            get;
            set;
        }
        /// <summary>
        /// The id of the frame that initiated the request.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// How the requested resource will be used.
        /// </summary>
        [JsonPropertyName("resourceType")]
        public ResourceType ResourceType
        {
            get;
            set;
        }
        /// <summary>
        /// Whether this is a navigation request, which can abort the navigation completely.
        /// </summary>
        [JsonPropertyName("isNavigationRequest")]
        public bool IsNavigationRequest
        {
            get;
            set;
        }
        /// <summary>
        /// Set if the request is a navigation that will result in a download.
        /// Only present after response is received from the server (i.e. HeadersReceived stage).
        /// </summary>
        [JsonPropertyName("isDownload")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsDownload
        {
            get;
            set;
        }
        /// <summary>
        /// Redirect location, only sent if a redirect was intercepted.
        /// </summary>
        [JsonPropertyName("redirectUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RedirectUrl
        {
            get;
            set;
        }
        /// <summary>
        /// Details of the Authorization Challenge encountered. If this is set then
        /// continueInterceptedRequest must contain an authChallengeResponse.
        /// </summary>
        [JsonPropertyName("authChallenge")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AuthChallenge AuthChallenge
        {
            get;
            set;
        }
        /// <summary>
        /// Response error if intercepted at response stage or if redirect occurred while intercepting
        /// request.
        /// </summary>
        [JsonPropertyName("responseErrorReason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ErrorReason? ResponseErrorReason
        {
            get;
            set;
        }
        /// <summary>
        /// Response code if intercepted at response stage or if redirect occurred while intercepting
        /// request or auth retry occurred.
        /// </summary>
        [JsonPropertyName("responseStatusCode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ResponseStatusCode
        {
            get;
            set;
        }
        /// <summary>
        /// Response headers if intercepted at the response stage or if redirect occurred while
        /// intercepting request or auth retry occurred.
        /// </summary>
        [JsonPropertyName("responseHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Headers ResponseHeaders
        {
            get;
            set;
        }
        /// <summary>
        /// If the intercepted request had a corresponding requestWillBeSent event fired for it, then
        /// this requestId will be the same as the requestId present in the requestWillBeSent event.
        /// </summary>
        [JsonPropertyName("requestId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RequestId
        {
            get;
            set;
        }
    }
}