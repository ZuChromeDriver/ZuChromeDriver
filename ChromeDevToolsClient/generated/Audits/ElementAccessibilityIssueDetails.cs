namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This issue warns about errors in the select or summary element content model.
    /// </summary>
    public sealed class ElementAccessibilityIssueDetails
    {
        /// <summary>
        /// Gets or sets the nodeId
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the elementAccessibilityIssueReason
        /// </summary>
        [JsonPropertyName("elementAccessibilityIssueReason")]
        public ElementAccessibilityIssueReason ElementAccessibilityIssueReason
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the hasDisallowedAttributes
        /// </summary>
        [JsonPropertyName("hasDisallowedAttributes")]
        public bool HasDisallowedAttributes
        {
            get;
            set;
        }
    }
}