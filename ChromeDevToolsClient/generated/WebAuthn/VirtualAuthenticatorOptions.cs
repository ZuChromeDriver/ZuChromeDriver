namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class VirtualAuthenticatorOptions
    {
        /// <summary>
        /// Gets or sets the protocol
        /// </summary>
        [JsonPropertyName("protocol")]
        public AuthenticatorProtocol Protocol
        {
            get;
            set;
        }
        /// <summary>
        /// Defaults to ctap2_0. Ignored if |protocol| == u2f.
        ///</summary>
        [JsonPropertyName("ctap2Version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Ctap2Version? Ctap2Version
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the transport
        /// </summary>
        [JsonPropertyName("transport")]
        public AuthenticatorTransport Transport
        {
            get;
            set;
        }
        /// <summary>
        /// Defaults to false.
        ///</summary>
        [JsonPropertyName("hasResidentKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HasResidentKey
        {
            get;
            set;
        }
        /// <summary>
        /// Defaults to false.
        ///</summary>
        [JsonPropertyName("hasUserVerification")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HasUserVerification
        {
            get;
            set;
        }
        /// <summary>
        /// If set to true, the authenticator will support the largeBlob extension.
        /// https://w3c.github.io/webauthn#largeBlob
        /// Defaults to false.
        ///</summary>
        [JsonPropertyName("hasLargeBlob")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HasLargeBlob
        {
            get;
            set;
        }
        /// <summary>
        /// If set to true, the authenticator will support the credBlob extension.
        /// https://fidoalliance.org/specs/fido-v2.1-rd-20201208/fido-client-to-authenticator-protocol-v2.1-rd-20201208.html#sctn-credBlob-extension
        /// Defaults to false.
        ///</summary>
        [JsonPropertyName("hasCredBlob")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HasCredBlob
        {
            get;
            set;
        }
        /// <summary>
        /// If set to true, the authenticator will support the minPinLength extension.
        /// https://fidoalliance.org/specs/fido-v2.1-ps-20210615/fido-client-to-authenticator-protocol-v2.1-ps-20210615.html#sctn-minpinlength-extension
        /// Defaults to false.
        ///</summary>
        [JsonPropertyName("hasMinPinLength")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HasMinPinLength
        {
            get;
            set;
        }
        /// <summary>
        /// If set to true, the authenticator will support the prf extension.
        /// https://w3c.github.io/webauthn/#prf-extension
        /// Defaults to false.
        ///</summary>
        [JsonPropertyName("hasPrf")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HasPrf
        {
            get;
            set;
        }
        /// <summary>
        /// If set to true, the authenticator will support the hmac-secret extension.
        /// https://fidoalliance.org/specs/fido-v2.1-ps-20210615/fido-client-to-authenticator-protocol-v2.1-ps-20210615.html#sctn-hmac-secret-extension
        /// Defaults to false.
        ///</summary>
        [JsonPropertyName("hasHmacSecret")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HasHmacSecret
        {
            get;
            set;
        }
        /// <summary>
        /// If set to true, the authenticator will support the hmac-secret-mc extension.
        /// https://fidoalliance.org/specs/fido-v2.2-rd-20241003/fido-client-to-authenticator-protocol-v2.2-rd-20241003.html#sctn-hmac-secret-make-cred-extension
        /// Defaults to false.
        ///</summary>
        [JsonPropertyName("hasHmacSecretMc")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HasHmacSecretMc
        {
            get;
            set;
        }
        /// <summary>
        /// If set to true, tests of user presence will succeed immediately.
        /// Otherwise, they will not be resolved. Defaults to true.
        ///</summary>
        [JsonPropertyName("automaticPresenceSimulation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? AutomaticPresenceSimulation
        {
            get;
            set;
        }
        /// <summary>
        /// Sets whether User Verification succeeds or fails for an authenticator.
        /// Defaults to false.
        ///</summary>
        [JsonPropertyName("isUserVerified")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsUserVerified
        {
            get;
            set;
        }
        /// <summary>
        /// Credentials created by this authenticator will have the backup
        /// eligibility (BE) flag set to this value. Defaults to false.
        /// https://w3c.github.io/webauthn/#sctn-credential-backup
        ///</summary>
        [JsonPropertyName("defaultBackupEligibility")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? DefaultBackupEligibility
        {
            get;
            set;
        }
        /// <summary>
        /// Credentials created by this authenticator will have the backup state
        /// (BS) flag set to this value. Defaults to false.
        /// https://w3c.github.io/webauthn/#sctn-credential-backup
        ///</summary>
        [JsonPropertyName("defaultBackupState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? DefaultBackupState
        {
            get;
            set;
        }
    }
}