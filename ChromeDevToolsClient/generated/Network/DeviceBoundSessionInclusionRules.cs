namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A device bound session's inclusion rules.
    /// </summary>
    public sealed class DeviceBoundSessionInclusionRules
    {
        /// <summary>
        /// See comments on `net::device_bound_sessions::SessionInclusionRules::origin_`.
        ///</summary>
        [JsonPropertyName("origin")]
        public string Origin
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the whole site is included. See comments on
        /// `net::device_bound_sessions::SessionInclusionRules::include_site_` for more
        /// details; this boolean is true if that value is populated.
        ///</summary>
        [JsonPropertyName("includeSite")]
        public bool IncludeSite
        {
            get;
            set;
        }
        /// <summary>
        /// See comments on `net::device_bound_sessions::SessionInclusionRules::url_rules_`.
        ///</summary>
        [JsonPropertyName("urlRules")]
        public DeviceBoundSessionUrlRule[] UrlRules
        {
            get;
            set;
        }
    }
}