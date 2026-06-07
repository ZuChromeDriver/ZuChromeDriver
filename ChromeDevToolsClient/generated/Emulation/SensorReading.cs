namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SensorReading
    {
        /// <summary>
        /// Gets or sets the single
        /// </summary>
        [JsonPropertyName("single")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SensorReadingSingle Single
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the xyz
        /// </summary>
        [JsonPropertyName("xyz")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SensorReadingXYZ Xyz
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the quaternion
        /// </summary>
        [JsonPropertyName("quaternion")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SensorReadingQuaternion Quaternion
        {
            get;
            set;
        }
    }
}