namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Overrides the Geolocation Position or Error. Omitting latitude, longitude or
    /// accuracy emulates position unavailable.
    /// </summary>
    public sealed class SetGeolocationOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setGeolocationOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Mock latitude
        /// </summary>
        [JsonPropertyName("latitude")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Latitude
        {
            get;
            set;
        }
        /// <summary>
        /// Mock longitude
        /// </summary>
        [JsonPropertyName("longitude")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Longitude
        {
            get;
            set;
        }
        /// <summary>
        /// Mock accuracy
        /// </summary>
        [JsonPropertyName("accuracy")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Accuracy
        {
            get;
            set;
        }
        /// <summary>
        /// Mock altitude
        /// </summary>
        [JsonPropertyName("altitude")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Altitude
        {
            get;
            set;
        }
        /// <summary>
        /// Mock altitudeAccuracy
        /// </summary>
        [JsonPropertyName("altitudeAccuracy")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? AltitudeAccuracy
        {
            get;
            set;
        }
        /// <summary>
        /// Mock heading
        /// </summary>
        [JsonPropertyName("heading")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Heading
        {
            get;
            set;
        }
        /// <summary>
        /// Mock speed
        /// </summary>
        [JsonPropertyName("speed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Speed
        {
            get;
            set;
        }
    }

    public sealed class SetGeolocationOverrideCommandResponse : ICommandResponse<SetGeolocationOverrideCommand>
    {
    }
}