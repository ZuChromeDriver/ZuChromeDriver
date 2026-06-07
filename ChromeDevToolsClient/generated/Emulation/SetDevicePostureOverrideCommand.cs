namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Start reporting the given posture value to the Device Posture API.
    /// This override can also be set in setDeviceMetricsOverride().
    /// </summary>
    public sealed class SetDevicePostureOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setDevicePostureOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the posture
        /// </summary>
        [JsonPropertyName("posture")]
        public DevicePosture Posture
        {
            get;
            set;
        }
    }

    public sealed class SetDevicePostureOverrideCommandResponse : ICommandResponse<SetDevicePostureOverrideCommand>
    {
    }
}