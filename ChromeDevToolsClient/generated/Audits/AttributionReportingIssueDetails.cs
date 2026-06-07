namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Details for issues around "Attribution Reporting API" usage.
    /// Explainer: https://github.com/WICG/attribution-reporting-api
    /// </summary>
    public sealed class AttributionReportingIssueDetails
    {
        /// <summary>
        /// Gets or sets the violationType
        /// </summary>
        [JsonPropertyName("violationType")]
        public AttributionReportingIssueType ViolationType
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the request
        /// </summary>
        [JsonPropertyName("request")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AffectedRequest Request
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the violatingNodeId
        /// </summary>
        [JsonPropertyName("violatingNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ViolatingNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the invalidParameter
        /// </summary>
        [JsonPropertyName("invalidParameter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string InvalidParameter
        {
            get;
            set;
        }
    }
}