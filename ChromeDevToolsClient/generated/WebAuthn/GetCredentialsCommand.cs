namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns all the credentials stored in the given virtual authenticator.
    /// </summary>
    public sealed class GetCredentialsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "WebAuthn.getCredentials";
        
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

    public sealed class GetCredentialsCommandResponse : ICommandResponse<GetCredentialsCommand>
    {
        /// <summary>
        /// Gets or sets the credentials
        /// </summary>
        [JsonPropertyName("credentials")]
        public Credential[] Credentials
        {
            get;
            set;
        }
    }
}