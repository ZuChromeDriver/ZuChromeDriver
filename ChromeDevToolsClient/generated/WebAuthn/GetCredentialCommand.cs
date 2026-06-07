namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns a single credential stored in the given virtual authenticator that
    /// matches the credential ID.
    /// </summary>
    public sealed class GetCredentialCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "WebAuthn.getCredential";
        
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
    }

    public sealed class GetCredentialCommandResponse : ICommandResponse<GetCredentialCommand>
    {
        /// <summary>
        /// Gets or sets the credential
        /// </summary>
        [JsonPropertyName("credential")]
        public Credential Credential
        {
            get;
            set;
        }
    }
}