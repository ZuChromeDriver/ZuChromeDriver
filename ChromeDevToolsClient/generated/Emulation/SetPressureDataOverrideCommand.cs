namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Provides a given pressure data set that will be processed and eventually be
    /// delivered to PressureObserver users. |source| must have been previously
    /// overridden by setPressureSourceOverrideEnabled.
    /// </summary>
    public sealed class SetPressureDataOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setPressureDataOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
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
        /// Gets or sets the state
        /// </summary>
        [JsonPropertyName("state")]
        public PressureState State
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the ownContributionEstimate
        /// </summary>
        [JsonPropertyName("ownContributionEstimate")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? OwnContributionEstimate
        {
            get;
            set;
        }
    }

    public sealed class SetPressureDataOverrideCommandResponse : ICommandResponse<SetPressureDataOverrideCommand>
    {
    }
}