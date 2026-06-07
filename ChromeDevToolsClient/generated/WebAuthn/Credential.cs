namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class Credential
    {
        /// <summary>
        /// Gets or sets the credentialId
        /// </summary>
        [JsonPropertyName("credentialId")]
        public string CredentialId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the isResidentCredential
        /// </summary>
        [JsonPropertyName("isResidentCredential")]
        public bool IsResidentCredential
        {
            get;
            set;
        }
        /// <summary>
        /// Relying Party ID the credential is scoped to. Must be set when adding a
        /// credential.
        ///</summary>
        [JsonPropertyName("rpId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RpId
        {
            get;
            set;
        }
        /// <summary>
        /// The ECDSA P-256 private key in PKCS#8 format. (Encoded as a base64 string when passed over JSON)
        ///</summary>
        [JsonPropertyName("privateKey")]
        public string PrivateKey
        {
            get;
            set;
        }
        /// <summary>
        /// An opaque byte sequence with a maximum size of 64 bytes mapping the
        /// credential to a specific user. (Encoded as a base64 string when passed over JSON)
        ///</summary>
        [JsonPropertyName("userHandle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UserHandle
        {
            get;
            set;
        }
        /// <summary>
        /// Signature counter. This is incremented by one for each successful
        /// assertion.
        /// See https://w3c.github.io/webauthn/#signature-counter
        ///</summary>
        [JsonPropertyName("signCount")]
        public long SignCount
        {
            get;
            set;
        }
        /// <summary>
        /// The large blob associated with the credential.
        /// See https://w3c.github.io/webauthn/#sctn-large-blob-extension (Encoded as a base64 string when passed over JSON)
        ///</summary>
        [JsonPropertyName("largeBlob")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string LargeBlob
        {
            get;
            set;
        }
        /// <summary>
        /// Assertions returned by this credential will have the backup eligibility
        /// (BE) flag set to this value. Defaults to the authenticator's
        /// defaultBackupEligibility value.
        ///</summary>
        [JsonPropertyName("backupEligibility")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? BackupEligibility
        {
            get;
            set;
        }
        /// <summary>
        /// Assertions returned by this credential will have the backup state (BS)
        /// flag set to this value. Defaults to the authenticator's
        /// defaultBackupState value.
        ///</summary>
        [JsonPropertyName("backupState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? BackupState
        {
            get;
            set;
        }
        /// <summary>
        /// The credential's user.name property. Equivalent to empty if not set.
        /// https://w3c.github.io/webauthn/#dom-publickeycredentialentity-name
        ///</summary>
        [JsonPropertyName("userName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UserName
        {
            get;
            set;
        }
        /// <summary>
        /// The credential's user.displayName property. Equivalent to empty if
        /// not set.
        /// https://w3c.github.io/webauthn/#dom-publickeycredentialuserentity-displayname
        ///</summary>
        [JsonPropertyName("userDisplayName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UserDisplayName
        {
            get;
            set;
        }
    }
}