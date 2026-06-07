namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when a prerender attempt is updated.
    /// </summary>
    public sealed class PrerenderStatusUpdatedEvent : IEvent
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
        /// Gets or sets the status
        /// </summary>
        [JsonPropertyName("status")]
        public PreloadingStatus Status
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the prerenderStatus
        /// </summary>
        [JsonPropertyName("prerenderStatus")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PrerenderFinalStatus? PrerenderStatus
        {
            get;
            set;
        }
        /// <summary>
        /// This is used to give users more information about the name of Mojo interface
        /// that is incompatible with prerender and has caused the cancellation of the attempt.
        /// </summary>
        [JsonPropertyName("disallowedMojoInterface")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DisallowedMojoInterface
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the mismatchedHeaders
        /// </summary>
        [JsonPropertyName("mismatchedHeaders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PrerenderMismatchedHeaders[] MismatchedHeaders
        {
            get;
            set;
        }
    }
}