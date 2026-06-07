namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Notifies that an existing AudioNode has been destroyed.
    /// </summary>
    public sealed class AudioNodeWillBeDestroyedEvent : IEvent
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
    }
}