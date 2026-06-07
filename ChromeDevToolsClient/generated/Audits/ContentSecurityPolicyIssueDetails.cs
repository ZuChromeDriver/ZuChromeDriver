namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ContentSecurityPolicyIssueDetails
    {
        /// <summary>
        /// The url not included in allowed sources.
        ///</summary>
        [JsonPropertyName("blockedURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BlockedURL
        {
            get;
            set;
        }
        /// <summary>
        /// Specific directive that is violated, causing the CSP issue.
        ///</summary>
        [JsonPropertyName("violatedDirective")]
        public string ViolatedDirective
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the isReportOnly
        /// </summary>
        [JsonPropertyName("isReportOnly")]
        public bool IsReportOnly
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the contentSecurityPolicyViolationType
        /// </summary>
        [JsonPropertyName("contentSecurityPolicyViolationType")]
        public ContentSecurityPolicyViolationType ContentSecurityPolicyViolationType
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the frameAncestor
        /// </summary>
        [JsonPropertyName("frameAncestor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AffectedFrame FrameAncestor
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
    }
}