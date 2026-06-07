namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Emulates the given media type or media feature for CSS media queries.
    /// </summary>
    public sealed class SetEmulatedMediaCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setEmulatedMedia";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Media type to emulate. Empty string disables the override.
        /// </summary>
        [JsonPropertyName("media")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Media
        {
            get;
            set;
        }
        /// <summary>
        /// Media features to emulate.
        /// </summary>
        [JsonPropertyName("features")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public MediaFeature[] Features
        {
            get;
            set;
        }
    }

    public sealed class SetEmulatedMediaCommandResponse : ICommandResponse<SetEmulatedMediaCommand>
    {
    }
}