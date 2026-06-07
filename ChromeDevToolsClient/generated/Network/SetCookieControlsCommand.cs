namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets Controls for third-party cookie access
    /// Page reload is required before the new cookie behavior will be observed
    /// </summary>
    public sealed class SetCookieControlsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.setCookieControls";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Whether 3pc restriction is enabled.
        /// </summary>
        [JsonPropertyName("enableThirdPartyCookieRestriction")]
        public bool EnableThirdPartyCookieRestriction
        {
            get;
            set;
        }
    }

    public sealed class SetCookieControlsCommandResponse : ICommandResponse<SetCookieControlsCommand>
    {
    }
}