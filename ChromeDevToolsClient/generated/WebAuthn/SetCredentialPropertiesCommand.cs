namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Allows setting credential properties.
    /// https://w3c.github.io/webauthn/#sctn-automation-set-credential-properties
    /// </summary>
    public sealed class SetCredentialPropertiesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "WebAuthn.setCredentialProperties";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the authenticatorId
        /// </summary>
        [JsonPropertyName("authenticatorId")]
        public string AuthenticatorId
        {
            get;
            set;
        }
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
        /// Gets or sets the backupEligibility
        /// </summary>
        [JsonPropertyName("backupEligibility")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? BackupEligibility
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the backupState
        /// </summary>
        [JsonPropertyName("backupState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? BackupState
        {
            get;
            set;
        }
    }

    public sealed class SetCredentialPropertiesCommandResponse : ICommandResponse<SetCredentialPropertiesCommand>
    {
    }
}