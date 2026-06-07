namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Notifies that existing BaseAudioContext has changed some properties (id stays the same)..
    /// </summary>
    public sealed class ContextChangedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the context
        /// </summary>
        [JsonPropertyName("context")]
        public BaseAudioContext Context
        {
            get;
            set;
        }
    }
}