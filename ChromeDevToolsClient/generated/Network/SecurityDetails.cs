namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Security details about a request.
    /// </summary>
    public sealed class SecurityDetails
    {
        /// <summary>
        /// Protocol name (e.g. "TLS 1.2" or "QUIC").
        ///</summary>
        [JsonPropertyName("protocol")]
        public string Protocol
        {
            get;
            set;
        }
        /// <summary>
        /// Key Exchange used by the connection, or the empty string if not applicable.
        ///</summary>
        [JsonPropertyName("keyExchange")]
        public string KeyExchange
        {
            get;
            set;
        }
        /// <summary>
        /// (EC)DH group used by the connection, if applicable.
        ///</summary>
        [JsonPropertyName("keyExchangeGroup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string KeyExchangeGroup
        {
            get;
            set;
        }
        /// <summary>
        /// Cipher name.
        ///</summary>
        [JsonPropertyName("cipher")]
        public string Cipher
        {
            get;
            set;
        }
        /// <summary>
        /// TLS MAC. Note that AEAD ciphers do not have separate MACs.
        ///</summary>
        [JsonPropertyName("mac")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Mac
        {
            get;
            set;
        }
        /// <summary>
        /// Certificate ID value.
        ///</summary>
        [JsonPropertyName("certificateId")]
        public long CertificateId
        {
            get;
            set;
        }
        /// <summary>
        /// Certificate subject name.
        ///</summary>
        [JsonPropertyName("subjectName")]
        public string SubjectName
        {
            get;
            set;
        }
        /// <summary>
        /// Subject Alternative Name (SAN) DNS names and IP addresses.
        ///</summary>
        [JsonPropertyName("sanList")]
        public string[] SanList
        {
            get;
            set;
        }
        /// <summary>
        /// Name of the issuing CA.
        ///</summary>
        [JsonPropertyName("issuer")]
        public string Issuer
        {
            get;
            set;
        }
        /// <summary>
        /// Certificate valid from date.
        ///</summary>
        [JsonPropertyName("validFrom")]
        public double ValidFrom
        {
            get;
            set;
        }
        /// <summary>
        /// Certificate valid to (expiration) date
        ///</summary>
        [JsonPropertyName("validTo")]
        public double ValidTo
        {
            get;
            set;
        }
        /// <summary>
        /// List of signed certificate timestamps (SCTs).
        ///</summary>
        [JsonPropertyName("signedCertificateTimestampList")]
        public SignedCertificateTimestamp[] SignedCertificateTimestampList
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the request complied with Certificate Transparency policy
        ///</summary>
        [JsonPropertyName("certificateTransparencyCompliance")]
        public CertificateTransparencyCompliance CertificateTransparencyCompliance
        {
            get;
            set;
        }
        /// <summary>
        /// The signature algorithm used by the server in the TLS server signature,
        /// represented as a TLS SignatureScheme code point. Omitted if not
        /// applicable or not known.
        ///</summary>
        [JsonPropertyName("serverSignatureAlgorithm")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ServerSignatureAlgorithm
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the connection used Encrypted ClientHello
        ///</summary>
        [JsonPropertyName("encryptedClientHello")]
        public bool EncryptedClientHello
        {
            get;
            set;
        }
    }
}