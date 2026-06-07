namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Overrides a pressure source of a given type, as used by the Compute
    /// Pressure API, so that updates to PressureObserver.observe() are provided
    /// via setPressureStateOverride instead of being retrieved from
    /// platform-provided telemetry data.
    /// </summary>
    public sealed class SetPressureSourceOverrideEnabledCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setPressureSourceOverrideEnabled";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the enabled
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the source
        /// </summary>
        [JsonPropertyName("source")]
        public PressureSource Source
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the metadata
        /// </summary>
        [JsonPropertyName("metadata")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PressureMetadata Metadata
        {
            get;
            set;
        }
    }

    public sealed class SetPressureSourceOverrideEnabledCommandResponse : ICommandResponse<SetPressureSourceOverrideEnabledCommand>
    {
    }
}