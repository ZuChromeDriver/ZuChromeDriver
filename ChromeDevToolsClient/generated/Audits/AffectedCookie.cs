namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about a cookie that is affected by an inspector issue.
    /// </summary>
    public sealed class AffectedCookie
    {
        /// <summary>
        /// The following three properties uniquely identify a cookie
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the path
        /// </summary>
        [JsonPropertyName("path")]
        public string Path
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the domain
        /// </summary>
        [JsonPropertyName("domain")]
        public string Domain
        {
            get;
            set;
        }
    }
}