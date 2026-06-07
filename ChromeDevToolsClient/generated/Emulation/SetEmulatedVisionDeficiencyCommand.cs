namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Emulates the given vision deficiency.
    /// </summary>
    public sealed class SetEmulatedVisionDeficiencyCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setEmulatedVisionDeficiency";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Vision deficiency to emulate. Order: best-effort emulations come first, followed by any
        /// physiologically accurate emulations for medically recognized color vision deficiencies.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
    }

    public sealed class SetEmulatedVisionDeficiencyCommandResponse : ICommandResponse<SetEmulatedVisionDeficiencyCommand>
    {
    }
}