namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets whether User Verification succeeds or fails for an authenticator.
    /// The default is true.
    /// </summary>
    public sealed class SetUserVerifiedCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "WebAuthn.setUserVerified";
        
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
        /// Gets or sets the isUserVerified
        /// </summary>
        [JsonPropertyName("isUserVerified")]
        public bool IsUserVerified
        {
            get;
            set;
        }
    }

    public sealed class SetUserVerifiedCommandResponse : ICommandResponse<SetUserVerifiedCommand>
    {
    }
}