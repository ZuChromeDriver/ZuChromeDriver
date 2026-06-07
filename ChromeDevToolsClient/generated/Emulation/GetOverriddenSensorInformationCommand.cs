namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class GetOverriddenSensorInformationCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.getOverriddenSensorInformation";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonPropertyName("type")]
        public SensorType Type
        {
            get;
            set;
        }
    }

    public sealed class GetOverriddenSensorInformationCommandResponse : ICommandResponse<GetOverriddenSensorInformationCommand>
    {
        /// <summary>
        /// Gets or sets the requestedSamplingFrequency
        /// </summary>
        [JsonPropertyName("requestedSamplingFrequency")]
        public double RequestedSamplingFrequency
        {
            get;
            set;
        }
    }
}