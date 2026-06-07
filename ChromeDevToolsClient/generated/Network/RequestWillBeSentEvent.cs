namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when page is about to send HTTP request.
    /// </summary>
    public sealed class RequestWillBeSentEvent : IEvent
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
        /// Loader identifier. Empty string if the request is fetched from worker.
        /// </summary>
        [JsonPropertyName("loaderId")]
        public string LoaderId
        {
            get;
            set;
        }
        /// <summary>
        /// URL of the document this request is loaded for.
        /// </summary>
        [JsonPropertyName("documentURL")]
        public string DocumentURL
        {
            get;
            set;
        }
        /// <summary>
        /// Request data.
        /// </summary>
        [JsonPropertyName("request")]
        public Request Request
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
        /// Timestamp.
        /// </summary>
        [JsonPropertyName("wallTime")]
        public double WallTime
        {
            get;
            set;
        }
        /// <summary>
        /// Request initiator.
        /// </summary>
        [JsonPropertyName("initiator")]
        public Initiator Initiator
        {
            get;
            set;
        }
        /// <summary>
        /// In the case that redirectResponse is populated, this flag indicates whether
        /// requestWillBeSentExtraInfo and responseReceivedExtraInfo events will be or were emitted
        /// for the request which was just redirected.
        /// </summary>
        [JsonPropertyName("redirectHasExtraInfo")]
        public bool RedirectHasExtraInfo
        {
            get;
            set;
        }
        /// <summary>
        /// Redirect response data.
        /// </summary>
        [JsonPropertyName("redirectResponse")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Response RedirectResponse
        {
            get;
            set;
        }
        /// <summary>
        /// Type of this resource.
        /// </summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ResourceType? Type
        {
            get;
            set;
        }
        /// <summary>
        /// Frame identifier.
        /// </summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the request is initiated by a user gesture. Defaults to false.
        /// </summary>
        [JsonPropertyName("hasUserGesture")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HasUserGesture
        {
            get;
            set;
        }
        /// <summary>
        /// The render-blocking behavior of the request.
        /// </summary>
        [JsonPropertyName("renderBlockingBehavior")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RenderBlockingBehavior? RenderBlockingBehavior
        {
            get;
            set;
        }
    }
}