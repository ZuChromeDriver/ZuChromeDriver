namespace Zu.ChromeDevTools.DeviceOrientation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Overrides the Device Orientation.
    /// </summary>
    public sealed class SetDeviceOrientationOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DeviceOrientation.setDeviceOrientationOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Mock alpha
        /// </summary>
        [JsonPropertyName("alpha")]
        public double Alpha
        {
            get;
            set;
        }
        /// <summary>
        /// Mock beta
        /// </summary>
        [JsonPropertyName("beta")]
        public double Beta
        {
            get;
            set;
        }
        /// <summary>
        /// Mock gamma
        /// </summary>
        [JsonPropertyName("gamma")]
        public double Gamma
        {
            get;
            set;
        }
    }

    public sealed class SetDeviceOrientationOverrideCommandResponse : ICommandResponse<SetDeviceOrientationOverrideCommand>
    {
    }
}