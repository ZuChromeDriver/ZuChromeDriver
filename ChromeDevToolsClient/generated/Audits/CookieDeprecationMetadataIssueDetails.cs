namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This issue warns about third-party sites that are accessing cookies on the
    /// current page, and have been permitted due to having a global metadata grant.
    /// Note that in this context 'site' means eTLD+1. For example, if the URL
    /// `https://example.test:80/web_page` was accessing cookies, the site reported
    /// would be `example.test`.
    /// </summary>
    public sealed class CookieDeprecationMetadataIssueDetails
    {
        /// <summary>
        /// Gets or sets the allowedSites
        /// </summary>
        [JsonPropertyName("allowedSites")]
        public string[] AllowedSites
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the optOutPercentage
        /// </summary>
        [JsonPropertyName("optOutPercentage")]
        public double OptOutPercentage
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the isOptOutTopLevel
        /// </summary>
        [JsonPropertyName("isOptOutTopLevel")]
        public bool IsOptOutTopLevel
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the operation
        /// </summary>
        [JsonPropertyName("operation")]
        public CookieOperation Operation
        {
            get;
            set;
        }
    }
}