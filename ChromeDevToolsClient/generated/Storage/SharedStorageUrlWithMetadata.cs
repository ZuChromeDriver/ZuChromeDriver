namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Bundles a candidate URL with its reporting metadata.
    /// </summary>
    public sealed class SharedStorageUrlWithMetadata
    {
        /// <summary>
        /// Spec of candidate URL.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Any associated reporting metadata.
        ///</summary>
        [JsonPropertyName("reportingMetadata")]
        public SharedStorageReportingMetadata[] ReportingMetadata
        {
            get;
            set;
        }
    }
}