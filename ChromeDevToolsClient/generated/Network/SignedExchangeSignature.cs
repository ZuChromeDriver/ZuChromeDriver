namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about a signed exchange signature.
    /// https://wicg.github.io/webpackage/draft-yasskin-httpbis-origin-signed-exchanges-impl.html#rfc.section.3.1
    /// </summary>
    public sealed class SignedExchangeSignature
    {
        /// <summary>
        /// Signed exchange signature label.
        ///</summary>
        [JsonPropertyName("label")]
        public string Label
        {
            get;
            set;
        }
        /// <summary>
        /// The hex string of signed exchange signature.
        ///</summary>
        [JsonPropertyName("signature")]
        public string Signature
        {
            get;
            set;
        }
        /// <summary>
        /// Signed exchange signature integrity.
        ///</summary>
        [JsonPropertyName("integrity")]
        public string Integrity
        {
            get;
            set;
        }
        /// <summary>
        /// Signed exchange signature cert Url.
        ///</summary>
        [JsonPropertyName("certUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string CertUrl
        {
            get;
            set;
        }
        /// <summary>
        /// The hex string of signed exchange signature cert sha256.
        ///</summary>
        [JsonPropertyName("certSha256")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string CertSha256
        {
            get;
            set;
        }
        /// <summary>
        /// Signed exchange signature validity Url.
        ///</summary>
        [JsonPropertyName("validityUrl")]
        public string ValidityUrl
        {
            get;
            set;
        }
        /// <summary>
        /// Signed exchange signature date.
        ///</summary>
        [JsonPropertyName("date")]
        public long Date
        {
            get;
            set;
        }
        /// <summary>
        /// Signed exchange signature expires.
        ///</summary>
        [JsonPropertyName("expires")]
        public long Expires
        {
            get;
            set;
        }
        /// <summary>
        /// The encoded certificates.
        ///</summary>
        [JsonPropertyName("certificates")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] Certificates
        {
            get;
            set;
        }
    }
}