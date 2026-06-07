namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Parsed app manifest properties.
    /// </summary>
    public sealed class AppManifestParsedProperties
    {
        /// <summary>
        /// Computed scope value
        ///</summary>
        [JsonPropertyName("scope")]
        public string Scope
        {
            get;
            set;
        }
    }
}