namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Notifies that a new AudioListener has been created.
    /// </summary>
    public sealed class AudioListenerWillBeDestroyedEvent : IEvent
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
        /// Gets or sets the listenerId
        /// </summary>
        [JsonPropertyName("listenerId")]
        public string ListenerId
        {
            get;
            set;
        }
    }
}