namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets up tracking device bound sessions and fetching of initial set of sessions.
    /// </summary>
    public sealed class EnableDeviceBoundSessionsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.enableDeviceBoundSessions";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Whether to enable or disable events.
        /// </summary>
        [JsonPropertyName("enable")]
        public bool Enable
        {
            get;
            set;
        }
    }

    public sealed class EnableDeviceBoundSessionsCommandResponse : ICommandResponse<EnableDeviceBoundSessionsCommand>
    {
    }
}