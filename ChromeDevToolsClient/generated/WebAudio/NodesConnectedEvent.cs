namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Notifies that two AudioNodes are connected.
    /// </summary>
    public sealed class NodesConnectedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the contextId
        /// </summary>
        [JsonPropertyName("contextId")]
        public string ContextId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the sourceId
        /// </summary>
        [JsonPropertyName("sourceId")]
        public string SourceId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the destinationId
        /// </summary>
        [JsonPropertyName("destinationId")]
        public string DestinationId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the sourceOutputIndex
        /// </summary>
        [JsonPropertyName("sourceOutputIndex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? SourceOutputIndex
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the destinationInputIndex
        /// </summary>
        [JsonPropertyName("destinationInputIndex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? DestinationInputIndex
        {
            get;
            set;
        }
    }
}