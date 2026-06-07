namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Creates and adds a virtual authenticator.
    /// </summary>
    public sealed class AddVirtualAuthenticatorCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "WebAuthn.addVirtualAuthenticator";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the options
        /// </summary>
        [JsonPropertyName("options")]
        public VirtualAuthenticatorOptions Options
        {
            get;
            set;
        }
    }

    public sealed class AddVirtualAuthenticatorCommandResponse : ICommandResponse<AddVirtualAuthenticatorCommand>
    {
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
}