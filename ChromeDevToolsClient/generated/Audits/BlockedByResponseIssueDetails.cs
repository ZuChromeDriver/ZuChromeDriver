namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Details for a request that has been blocked with the BLOCKED_BY_RESPONSE
    /// code. Currently only used for COEP/COOP, but may be extended to include
    /// some CSP errors in the future.
    /// </summary>
    public sealed class BlockedByResponseIssueDetails
    {
        /// <summary>
        /// Gets or sets the request
        /// </summary>
        [JsonPropertyName("request")]
        public AffectedRequest Request
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the parentFrame
        /// </summary>
        [JsonPropertyName("parentFrame")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AffectedFrame ParentFrame
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the blockedFrame
        /// </summary>
        [JsonPropertyName("blockedFrame")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AffectedFrame BlockedFrame
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the reason
        /// </summary>
        [JsonPropertyName("reason")]
        public BlockedByResponseReason Reason
        {
            get;
            set;
        }
    }
}