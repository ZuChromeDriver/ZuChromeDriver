namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Toggles mouse event-based touch event emulation.
    /// </summary>
    public sealed class SetTouchEmulationEnabledCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.setTouchEmulationEnabled";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Whether the touch event emulation should be enabled.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled
        {
            get;
            set;
        }
        /// <summary>
        /// Touch/gesture events configuration. Default: current platform.
        /// </summary>
        [JsonPropertyName("configuration")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Configuration
        {
            get;
            set;
        }
    }

    public sealed class SetTouchEmulationEnabledCommandResponse : ICommandResponse<SetTouchEmulationEnabledCommand>
    {
    }
}