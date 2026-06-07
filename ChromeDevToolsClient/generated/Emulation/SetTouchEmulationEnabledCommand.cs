namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enables touch on platforms which do not support them.
    /// </summary>
    public sealed class SetTouchEmulationEnabledCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setTouchEmulationEnabled";
        
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
        /// Maximum touch points supported. Defaults to one.
        /// </summary>
        [JsonPropertyName("maxTouchPoints")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? MaxTouchPoints
        {
            get;
            set;
        }
    }

    public sealed class SetTouchEmulationEnabledCommandResponse : ICommandResponse<SetTouchEmulationEnabledCommand>
    {
    }
}