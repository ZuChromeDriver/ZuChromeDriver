namespace Zu.ChromeDevTools.Memory
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enable/disable suppressing memory pressure notifications in all processes.
    /// </summary>
    public sealed class SetPressureNotificationsSuppressedCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Memory.setPressureNotificationsSuppressed";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// If true, memory pressure notifications will be suppressed.
        /// </summary>
        [JsonPropertyName("suppressed")]
        public bool Suppressed
        {
            get;
            set;
        }
    }

    public sealed class SetPressureNotificationsSuppressedCommandResponse : ICommandResponse<SetPressureNotificationsSuppressedCommand>
    {
    }
}