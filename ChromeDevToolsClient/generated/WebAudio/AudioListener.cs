namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Protocol object for AudioListener
    /// </summary>
    public sealed class AudioListener
    {
        /// <summary>
        /// Gets or sets the listenerId
        /// </summary>
        [JsonPropertyName("listenerId")]
        public string ListenerId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the contextId
        /// </summary>
        [JsonPropertyName("contextId")]
        public string ContextId
        {
            get;
            set;
        }
    }
}