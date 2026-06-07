namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A device bound session.
    /// </summary>
    public sealed class DeviceBoundSession
    {
        /// <summary>
        /// The site and session ID of the session.
        ///</summary>
        [JsonPropertyName("key")]
        public DeviceBoundSessionKey Key
        {
            get;
            set;
        }
        /// <summary>
        /// See comments on `net::device_bound_sessions::Session::refresh_url_`.
        ///</summary>
        [JsonPropertyName("refreshUrl")]
        public string RefreshUrl
        {
            get;
            set;
        }
        /// <summary>
        /// See comments on `net::device_bound_sessions::Session::inclusion_rules_`.
        ///</summary>
        [JsonPropertyName("inclusionRules")]
        public DeviceBoundSessionInclusionRules InclusionRules
        {
            get;
            set;
        }
        /// <summary>
        /// See comments on `net::device_bound_sessions::Session::cookie_cravings_`.
        ///</summary>
        [JsonPropertyName("cookieCravings")]
        public DeviceBoundSessionCookieCraving[] CookieCravings
        {
            get;
            set;
        }
        /// <summary>
        /// See comments on `net::device_bound_sessions::Session::expiry_date_`.
        ///</summary>
        [JsonPropertyName("expiryDate")]
        public double ExpiryDate
        {
            get;
            set;
        }
        /// <summary>
        /// See comments on `net::device_bound_sessions::Session::cached_challenge__`.
        ///</summary>
        [JsonPropertyName("cachedChallenge")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string CachedChallenge
        {
            get;
            set;
        }
        /// <summary>
        /// See comments on `net::device_bound_sessions::Session::allowed_refresh_initiators_`.
        ///</summary>
        [JsonPropertyName("allowedRefreshInitiators")]
        public string[] AllowedRefreshInitiators
        {
            get;
            set;
        }
    }
}