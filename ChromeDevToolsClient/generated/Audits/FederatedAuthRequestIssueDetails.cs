namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class FederatedAuthRequestIssueDetails
    {
        /// <summary>
        /// Gets or sets the federatedAuthRequestIssueReason
        /// </summary>
        [JsonPropertyName("federatedAuthRequestIssueReason")]
        public FederatedAuthRequestIssueReason FederatedAuthRequestIssueReason
        {
            get;
            set;
        }
    }
}