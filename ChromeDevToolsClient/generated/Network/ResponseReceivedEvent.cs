namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when HTTP response is available.
    /// </summary>
    public sealed class ResponseReceivedEvent : IEvent
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
        /// Timestamp.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public double Timestamp
        {
            get;
            set;
        }
        /// <summary>
        /// Resource type.
        /// </summary>
        [JsonPropertyName("type")]
        public ResourceType Type
        {
            get;
            set;
        }
        /// <summary>
        /// Response data.
        /// </summary>
        [JsonPropertyName("response")]
        public Response Response
        {
            get;
            set;
        }
        /// <summary>
        /// Indicates whether requestWillBeSentExtraInfo and responseReceivedExtraInfo events will be
        /// or were emitted for this request.
        /// </summary>
        [JsonPropertyName("hasExtraInfo")]
        public bool HasExtraInfo
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
    }
}