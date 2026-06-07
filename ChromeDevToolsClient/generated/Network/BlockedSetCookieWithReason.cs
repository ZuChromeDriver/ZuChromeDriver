namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A cookie which was not stored from a response with the corresponding reason.
    /// </summary>
    public sealed class BlockedSetCookieWithReason
    {
        /// <summary>
        /// The reason(s) this cookie was blocked.
        ///</summary>
        [JsonPropertyName("blockedReasons")]
        public SetCookieBlockedReason[] BlockedReasons
        {
            get;
            set;
        }
        /// <summary>
        /// The string representing this individual cookie as it would appear in the header.
        /// This is not the entire "cookie" or "set-cookie" header which could have multiple cookies.
        ///</summary>
        [JsonPropertyName("cookieLine")]
        public string CookieLine
        {
            get;
            set;
        }
        /// <summary>
        /// The cookie object which represents the cookie which was not stored. It is optional because
        /// sometimes complete cookie information is not available, such as in the case of parsing
        /// errors.
        ///</summary>
        [JsonPropertyName("cookie")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Cookie Cookie
        {
            get;
            set;
        }
    }
}