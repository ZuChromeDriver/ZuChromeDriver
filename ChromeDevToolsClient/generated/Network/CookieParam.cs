namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Cookie parameter object
    /// </summary>
    public sealed class CookieParam
    {
        /// <summary>
        /// Cookie name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Cookie value.
        ///</summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
        /// <summary>
        /// The request-URI to associate with the setting of the cookie. This value can affect the
        /// default domain, path, source port, and source scheme values of the created cookie.
        ///</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Cookie domain.
        ///</summary>
        [JsonPropertyName("domain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Domain
        {
            get;
            set;
        }
        /// <summary>
        /// Cookie path.
        ///</summary>
        [JsonPropertyName("path")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Path
        {
            get;
            set;
        }
        /// <summary>
        /// True if cookie is secure.
        ///</summary>
        [JsonPropertyName("secure")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Secure
        {
            get;
            set;
        }
        /// <summary>
        /// True if cookie is http-only.
        ///</summary>
        [JsonPropertyName("httpOnly")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HttpOnly
        {
            get;
            set;
        }
        /// <summary>
        /// Cookie SameSite type.
        ///</summary>
        [JsonPropertyName("sameSite")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CookieSameSite? SameSite
        {
            get;
            set;
        }
        /// <summary>
        /// Cookie expiration date, session cookie if not set
        ///</summary>
        [JsonPropertyName("expires")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Expires
        {
            get;
            set;
        }
        /// <summary>
        /// Cookie Priority.
        ///</summary>
        [JsonPropertyName("priority")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CookiePriority? Priority
        {
            get;
            set;
        }
        /// <summary>
        /// Cookie source scheme type.
        ///</summary>
        [JsonPropertyName("sourceScheme")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CookieSourceScheme? SourceScheme
        {
            get;
            set;
        }
        /// <summary>
        /// Cookie source port. Valid values are {-1, [1, 65535]}, -1 indicates an unspecified port.
        /// An unspecified port value allows protocol clients to emulate legacy cookie scope for the port.
        /// This is a temporary ability and it will be removed in the future.
        ///</summary>
        [JsonPropertyName("sourcePort")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? SourcePort
        {
            get;
            set;
        }
        /// <summary>
        /// Cookie partition key. If not set, the cookie will be set as not partitioned.
        ///</summary>
        [JsonPropertyName("partitionKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CookiePartitionKey PartitionKey
        {
            get;
            set;
        }
    }
}