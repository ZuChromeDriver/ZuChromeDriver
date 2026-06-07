namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Notifies that the construction of an AudioListener has finished.
    /// </summary>
    public sealed class AudioListenerCreatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the listener
        /// </summary>
        [JsonPropertyName("listener")]
        public AudioListener Listener
        {
            get;
            set;
        }
    }
}