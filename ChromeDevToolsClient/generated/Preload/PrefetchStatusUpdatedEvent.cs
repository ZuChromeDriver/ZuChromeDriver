namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when a prefetch attempt is updated.
    /// </summary>
    public sealed class PrefetchStatusUpdatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the key
        /// </summary>
        [JsonPropertyName("key")]
        public PreloadingAttemptKey Key
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the pipelineId
        /// </summary>
        [JsonPropertyName("pipelineId")]
        public string PipelineId
        {
            get;
            set;
        }
        /// <summary>
        /// The frame id of the frame initiating prefetch.
        /// </summary>
        [JsonPropertyName("initiatingFrameId")]
        public string InitiatingFrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the prefetchUrl
        /// </summary>
        [JsonPropertyName("prefetchUrl")]
        public string PrefetchUrl
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the status
        /// </summary>
        [JsonPropertyName("status")]
        public PreloadingStatus Status
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the prefetchStatus
        /// </summary>
        [JsonPropertyName("prefetchStatus")]
        public PrefetchStatus PrefetchStatus
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the requestId
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
    }
}