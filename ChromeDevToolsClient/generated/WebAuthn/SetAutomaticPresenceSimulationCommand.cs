namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets whether tests of user presence will succeed immediately (if true) or fail to resolve (if false) for an authenticator.
    /// The default is true.
    /// </summary>
    public sealed class SetAutomaticPresenceSimulationCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "WebAuthn.setAutomaticPresenceSimulation";
        
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
        /// Gets or sets the enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled
        {
            get;
            set;
        }
    }

    public sealed class SetAutomaticPresenceSimulationCommandResponse : ICommandResponse<SetAutomaticPresenceSimulationCommand>
    {
    }
}