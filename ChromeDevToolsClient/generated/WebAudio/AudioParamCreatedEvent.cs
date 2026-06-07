namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Notifies that a new AudioParam has been created.
    /// </summary>
    public sealed class AudioParamCreatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the param
        /// </summary>
        [JsonPropertyName("param")]
        public AudioParam Param
        {
            get;
            set;
        }
    }
}