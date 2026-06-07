namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when HTTP request has failed to load.
    /// </summary>
    public sealed class LoadingFailedEvent : IEvent
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
        /// Error message. List of network errors: https://cs.chromium.org/chromium/src/net/base/net_error_list.h
        /// </summary>
        [JsonPropertyName("errorText")]
        public string ErrorText
        {
            get;
            set;
        }
        /// <summary>
        /// True if loading was canceled.
        /// </summary>
        [JsonPropertyName("canceled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Canceled
        {
            get;
            set;
        }
        /// <summary>
        /// The reason why loading was blocked, if any.
        /// </summary>
        [JsonPropertyName("blockedReason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public BlockedReason? BlockedReason
        {
            get;
            set;
        }
        /// <summary>
        /// The reason why loading was blocked by CORS, if any.
        /// </summary>
        [JsonPropertyName("corsErrorStatus")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CorsErrorStatus CorsErrorStatus
        {
            get;
            set;
        }
    }
}