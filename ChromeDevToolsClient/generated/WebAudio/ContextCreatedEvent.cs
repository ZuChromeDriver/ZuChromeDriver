namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Notifies that a new BaseAudioContext has been created.
    /// </summary>
    public sealed class ContextCreatedEvent : IEvent
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