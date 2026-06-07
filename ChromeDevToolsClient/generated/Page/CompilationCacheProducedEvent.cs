namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued for every compilation cache generated.
    /// </summary>
    public sealed class CompilationCacheProducedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Base64-encoded data (Encoded as a base64 string when passed over JSON)
        /// </summary>
        [JsonPropertyName("data")]
        public string Data
        {
            get;
            set;
        }
    }
}