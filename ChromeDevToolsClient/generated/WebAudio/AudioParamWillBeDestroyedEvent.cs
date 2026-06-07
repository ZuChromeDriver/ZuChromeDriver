namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Notifies that an existing AudioParam has been destroyed.
    /// </summary>
    public sealed class AudioParamWillBeDestroyedEvent : IEvent
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
        /// Gets or sets the nodeId
        /// </summary>
        [JsonPropertyName("nodeId")]
        public string NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the paramId
        /// </summary>
        [JsonPropertyName("paramId")]
        public string ParamId
        {
            get;
            set;
        }
    }
}