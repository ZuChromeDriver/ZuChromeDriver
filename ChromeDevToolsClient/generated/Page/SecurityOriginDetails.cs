namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Additional information about the frame document's security origin.
    /// </summary>
    public sealed class SecurityOriginDetails
    {
        /// <summary>
        /// Indicates whether the frame document's security origin is one
        /// of the local hostnames (e.g. "localhost") or IP addresses (IPv4
        /// 127.0.0.0/8 or IPv6 ::1).
        ///</summary>
        [JsonPropertyName("isLocalhost")]
        public bool IsLocalhost
        {
            get;
            set;
        }
    }
}