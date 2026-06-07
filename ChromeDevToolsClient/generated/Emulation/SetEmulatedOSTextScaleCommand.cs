namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Emulates the given OS text scale.
    /// </summary>
    public sealed class SetEmulatedOSTextScaleCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setEmulatedOSTextScale";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the scale
        /// </summary>
        [JsonPropertyName("scale")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Scale
        {
            get;
            set;
        }
    }

    public sealed class SetEmulatedOSTextScaleCommandResponse : ICommandResponse<SetEmulatedOSTextScaleCommand>
    {
    }
}