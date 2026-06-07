namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SetEmitTouchEventsForMouseCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setEmitTouchEventsForMouse";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Whether touch emulation based on mouse input should be enabled.
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

    public sealed class SetEmitTouchEventsForMouseCommandResponse : ICommandResponse<SetEmitTouchEventsForMouseCommand>
    {
    }
}