namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A device bound session's cookie craving.
    /// </summary>
    public sealed class DeviceBoundSessionCookieCraving
    {
        /// <summary>
        /// The name of the craving.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// The domain of the craving.
        ///</summary>
        [JsonPropertyName("domain")]
        public string Domain
        {
            get;
            set;
        }
        /// <summary>
        /// The path of the craving.
        ///</summary>
        [JsonPropertyName("path")]
        public string Path
        {
            get;
            set;
        }
        /// <summary>
        /// The `Secure` attribute of the craving attributes.
        ///</summary>
        [JsonPropertyName("secure")]
        public bool Secure
        {
            get;
            set;
        }
        /// <summary>
        /// The `HttpOnly` attribute of the craving attributes.
        ///</summary>
        [JsonPropertyName("httpOnly")]
        public bool HttpOnly
        {
            get;
            set;
        }
        /// <summary>
        /// The `SameSite` attribute of the craving attributes.
        ///</summary>
        [JsonPropertyName("sameSite")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CookieSameSite? SameSite
        {
            get;
            set;
        }
    }
}