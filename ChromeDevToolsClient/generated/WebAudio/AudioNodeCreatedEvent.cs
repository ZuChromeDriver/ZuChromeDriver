namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Notifies that a new AudioNode has been created.
    /// </summary>
    public sealed class AudioNodeCreatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the node
        /// </summary>
        [JsonPropertyName("node")]
        public AudioNode Node
        {
            get;
            set;
        }
    }
}