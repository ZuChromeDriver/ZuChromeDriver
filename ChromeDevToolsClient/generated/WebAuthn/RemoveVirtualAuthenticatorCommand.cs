namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Removes the given authenticator.
    /// </summary>
    public sealed class RemoveVirtualAuthenticatorCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "WebAuthn.removeVirtualAuthenticator";
        
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
    }

    public sealed class RemoveVirtualAuthenticatorCommandResponse : ICommandResponse<RemoveVirtualAuthenticatorCommand>
    {
    }
}