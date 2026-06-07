namespace Zu.ChromeDevTools.Fetch
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when the domain is enabled and the request URL matches the
    /// specified filter. The request is paused until the client responds
    /// with one of continueRequest, failRequest or fulfillRequest.
    /// The stage of the request can be determined by presence of responseErrorReason
    /// and responseStatusCode -- the request is at the response stage if either
    /// of these fields is present and in the request stage otherwise.
    /// Redirect responses and subsequent requests are reported similarly to regular
    /// responses and requests. Redirect responses may be distinguished by the value
    /// of `responseStatusCode` (which is one of 301, 302, 303, 307, 308) along with
    /// presence of the `location` header. Requests resulting from a redirect will
    /// have `redirectedRequestId` field set.
    /// </summary>
    public sealed class RequestPausedEvent : IEvent
    {
        /// <summary>
        /// Each request the page makes will have a unique id.
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
        /// <summary>
        /// The details of the request.
        /// </summary>
        [JsonPropertyName("request")]
        public Network.Request Request
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
        public Network.ResourceType ResourceType
        {
            get;
            set;
        }
        /// <summary>
        /// Response error if intercepted at response stage.
        /// </summary>
        [JsonPropertyName("responseErrorReason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Network.ErrorReason? ResponseErrorReason
        {
            get;
            set;
        }
        /// <summary>
        /// Response code if intercepted at response stage.
        /// </summary>
        [JsonPropertyName("responseStatusCode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ResponseStatusCode
        {
            get;
            set;
        }
        /// <summary>
        /// Response status text if intercepted at response stage.
        /// </summary>
        [JsonPropertyName("responseStatusText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ResponseStatusText
        {
            get;
            set;
        }
        /// <summary>
        /// Response headers if intercepted at the response stage.
        /// </summary>
        [JsonPropertyName("responseHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public HeaderEntry[] ResponseHeaders
        {
            get;
            set;
        }
        /// <summary>
        /// If the intercepted request had a corresponding Network.requestWillBeSent event fired for it,
        /// then this networkId will be the same as the requestId present in the requestWillBeSent event.
        /// </summary>
        [JsonPropertyName("networkId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string NetworkId
        {
            get;
            set;
        }
        /// <summary>
        /// If the request is due to a redirect response from the server, the id of the request that
        /// has caused the redirect.
        /// </summary>
        [JsonPropertyName("redirectedRequestId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RedirectedRequestId
        {
            get;
            set;
        }
    }
}