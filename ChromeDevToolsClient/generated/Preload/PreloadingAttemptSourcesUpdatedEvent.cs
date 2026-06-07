namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Send a list of sources for all preloading attempts in a document.
    /// </summary>
    public sealed class PreloadingAttemptSourcesUpdatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the loaderId
        /// </summary>
        [JsonPropertyName("loaderId")]
        public string LoaderId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the preloadingAttemptSources
        /// </summary>
        [JsonPropertyName("preloadingAttemptSources")]
        public PreloadingAttemptSource[] PreloadingAttemptSources
        {
            get;
            set;
        }
    }
}