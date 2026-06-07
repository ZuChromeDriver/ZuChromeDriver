namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class FederatedAuthUserInfoRequestIssueDetails
    {
        /// <summary>
        /// Gets or sets the federatedAuthUserInfoRequestIssueReason
        /// </summary>
        [JsonPropertyName("federatedAuthUserInfoRequestIssueReason")]
        public FederatedAuthUserInfoRequestIssueReason FederatedAuthUserInfoRequestIssueReason
        {
            get;
            set;
        }
    }
}