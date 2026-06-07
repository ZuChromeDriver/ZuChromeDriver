namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class OriginTrialToken
    {
        /// <summary>
        /// Gets or sets the origin
        /// </summary>
        [JsonPropertyName("origin")]
        public string Origin
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the matchSubDomains
        /// </summary>
        [JsonPropertyName("matchSubDomains")]
        public bool MatchSubDomains
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the trialName
        /// </summary>
        [JsonPropertyName("trialName")]
        public string TrialName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the expiryTime
        /// </summary>
        [JsonPropertyName("expiryTime")]
        public double ExpiryTime
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the isThirdParty
        /// </summary>
        [JsonPropertyName("isThirdParty")]
        public bool IsThirdParty
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the usageRestriction
        /// </summary>
        [JsonPropertyName("usageRestriction")]
        public OriginTrialUsageRestriction UsageRestriction
        {
            get;
            set;
        }
    }
}