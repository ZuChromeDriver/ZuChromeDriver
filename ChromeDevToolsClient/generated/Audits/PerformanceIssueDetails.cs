namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Details for a performance issue.
    /// </summary>
    public sealed class PerformanceIssueDetails
    {
        /// <summary>
        /// Gets or sets the performanceIssueType
        /// </summary>
        [JsonPropertyName("performanceIssueType")]
        public PerformanceIssueType PerformanceIssueType
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the sourceCodeLocation
        /// </summary>
        [JsonPropertyName("sourceCodeLocation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SourceCodeLocation SourceCodeLocation
        {
            get;
            set;
        }
    }
}