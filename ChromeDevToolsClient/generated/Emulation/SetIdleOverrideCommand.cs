namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Overrides the Idle state.
    /// </summary>
    public sealed class SetIdleOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setIdleOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Mock isUserActive
        /// </summary>
        [JsonPropertyName("isUserActive")]
        public bool IsUserActive
        {
            get;
            set;
        }
        /// <summary>
        /// Mock isScreenUnlocked
        /// </summary>
        [JsonPropertyName("isScreenUnlocked")]
        public bool IsScreenUnlocked
        {
            get;
            set;
        }
    }

    public sealed class SetIdleOverrideCommandResponse : ICommandResponse<SetIdleOverrideCommand>
    {
    }
}