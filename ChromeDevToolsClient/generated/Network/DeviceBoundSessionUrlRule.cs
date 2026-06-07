namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A device bound session's inclusion URL rule.
    /// </summary>
    public sealed class DeviceBoundSessionUrlRule
    {
        /// <summary>
        /// See comments on `net::device_bound_sessions::SessionInclusionRules::UrlRule::rule_type`.
        ///</summary>
        [JsonPropertyName("ruleType")]
        public string RuleType
        {
            get;
            set;
        }
        /// <summary>
        /// See comments on `net::device_bound_sessions::SessionInclusionRules::UrlRule::host_pattern`.
        ///</summary>
        [JsonPropertyName("hostPattern")]
        public string HostPattern
        {
            get;
            set;
        }
        /// <summary>
        /// See comments on `net::device_bound_sessions::SessionInclusionRules::UrlRule::path_prefix`.
        ///</summary>
        [JsonPropertyName("pathPrefix")]
        public string PathPrefix
        {
            get;
            set;
        }
    }
}