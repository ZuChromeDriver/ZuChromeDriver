namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Pair of reporting metadata details for a candidate URL for `selectURL()`.
    /// </summary>
    public sealed class SharedStorageReportingMetadata
    {
        /// <summary>
        /// Gets or sets the eventType
        /// </summary>
        [JsonPropertyName("eventType")]
        public string EventType
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the reportingUrl
        /// </summary>
        [JsonPropertyName("reportingUrl")]
        public string ReportingUrl
        {
            get;
            set;
        }
    }
}