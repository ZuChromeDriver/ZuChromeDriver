namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Updates the sensor readings reported by a sensor type previously overridden
    /// by setSensorOverrideEnabled.
    /// </summary>
    public sealed class SetSensorOverrideReadingsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setSensorOverrideReadings";
        
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
        /// <summary>
        /// Gets or sets the reading
        /// </summary>
        [JsonPropertyName("reading")]
        public SensorReading Reading
        {
            get;
            set;
        }
    }

    public sealed class SetSensorOverrideReadingsCommandResponse : ICommandResponse<SetSensorOverrideReadingsCommand>
    {
    }
}