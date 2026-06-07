namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This information is currently necessary, as the front-end has a difficult
    /// time finding a specific cookie. With this, we can convey specific error
    /// information without the cookie.
    /// </summary>
    public sealed class CookieIssueDetails
    {
        /// <summary>
        /// If AffectedCookie is not set then rawCookieLine contains the raw
        /// Set-Cookie header string. This hints at a problem where the
        /// cookie line is syntactically or semantically malformed in a way
        /// that no valid cookie could be created.
        ///</summary>
        [JsonPropertyName("cookie")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AffectedCookie Cookie
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the rawCookieLine
        /// </summary>
        [JsonPropertyName("rawCookieLine")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RawCookieLine
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the cookieWarningReasons
        /// </summary>
        [JsonPropertyName("cookieWarningReasons")]
        public CookieWarningReason[] CookieWarningReasons
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the cookieExclusionReasons
        /// </summary>
        [JsonPropertyName("cookieExclusionReasons")]
        public CookieExclusionReason[] CookieExclusionReasons
        {
            get;
            set;
        }
        /// <summary>
        /// Optionally identifies the site-for-cookies and the cookie url, which
        /// may be used by the front-end as additional context.
        ///</summary>
        [JsonPropertyName("operation")]
        public CookieOperation Operation
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the siteForCookies
        /// </summary>
        [JsonPropertyName("siteForCookies")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SiteForCookies
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the cookieUrl
        /// </summary>
        [JsonPropertyName("cookieUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string CookieUrl
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the request
        /// </summary>
        [JsonPropertyName("request")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AffectedRequest Request
        {
            get;
            set;
        }
        /// <summary>
        /// The recommended solution to the issue.
        ///</summary>
        [JsonPropertyName("insight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CookieIssueInsight Insight
        {
            get;
            set;
        }
    }
}