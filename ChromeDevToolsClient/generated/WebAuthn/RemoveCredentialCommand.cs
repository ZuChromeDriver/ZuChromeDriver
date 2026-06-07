namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Removes a credential from the authenticator.
    /// </summary>
    public sealed class RemoveCredentialCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "WebAuthn.removeCredential";
        
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

    public sealed class RemoveCredentialCommandResponse : ICommandResponse<RemoveCredentialCommand>
    {
    }
}