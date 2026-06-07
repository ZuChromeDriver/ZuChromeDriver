namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Authorization challenge for HTTP status code 401 or 407.
    /// </summary>
    public sealed class AuthChallenge
    {
        /// <summary>
        /// Source of the authentication challenge.
        ///</summary>
        [JsonPropertyName("source")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Source
        {
            get;
            set;
        }
        /// <summary>
        /// Origin of the challenger.
        ///</summary>
        [JsonPropertyName("origin")]
        public string Origin
        {
            get;
            set;
        }
        /// <summary>
        /// The authentication scheme used, such as basic or digest
        ///</summary>
        [JsonPropertyName("scheme")]
        public string Scheme
        {
            get;
            set;
        }
        /// <summary>
        /// The realm of the challenge. May be empty.
        ///</summary>
        [JsonPropertyName("realm")]
        public string Realm
        {
            get;
            set;
        }
    }
}