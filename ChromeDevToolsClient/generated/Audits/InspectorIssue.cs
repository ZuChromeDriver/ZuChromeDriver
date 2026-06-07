namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// An inspector issue reported from the back-end.
    /// </summary>
    public sealed class InspectorIssue
    {
        /// <summary>
        /// Gets or sets the code
        /// </summary>
        [JsonPropertyName("code")]
        public InspectorIssueCode Code
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the details
        /// </summary>
        [JsonPropertyName("details")]
        public InspectorIssueDetails Details
        {
            get;
            set;
        }
        /// <summary>
        /// A unique id for this issue. May be omitted if no other entity (e.g.
        /// exception, CDP message, etc.) is referencing this issue.
        ///</summary>
        [JsonPropertyName("issueId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string IssueId
        {
            get;
            set;
        }
    }
}