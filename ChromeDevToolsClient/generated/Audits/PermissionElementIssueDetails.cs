namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This issue warns about improper usage of the <permission> element.
    /// </summary>
    public sealed class PermissionElementIssueDetails
    {
        /// <summary>
        /// Gets or sets the issueType
        /// </summary>
        [JsonPropertyName("issueType")]
        public PermissionElementIssueType IssueType
        {
            get;
            set;
        }
        /// <summary>
        /// The value of the type attribute.
        ///</summary>
        [JsonPropertyName("type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// The node ID of the <permission> element.
        ///</summary>
        [JsonPropertyName("nodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// True if the issue is a warning, false if it is an error.
        ///</summary>
        [JsonPropertyName("isWarning")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsWarning
        {
            get;
            set;
        }
        /// <summary>
        /// Fields for message construction:
        /// Used for messages that reference a specific permission name
        ///</summary>
        [JsonPropertyName("permissionName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PermissionName
        {
            get;
            set;
        }
        /// <summary>
        /// Used for messages about occlusion
        ///</summary>
        [JsonPropertyName("occluderNodeInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string OccluderNodeInfo
        {
            get;
            set;
        }
        /// <summary>
        /// Used for messages about occluder's parent
        ///</summary>
        [JsonPropertyName("occluderParentNodeInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string OccluderParentNodeInfo
        {
            get;
            set;
        }
        /// <summary>
        /// Used for messages about activation disabled reason
        ///</summary>
        [JsonPropertyName("disableReason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DisableReason
        {
            get;
            set;
        }
    }
}