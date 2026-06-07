namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SensorMetadata
    {
        /// <summary>
        /// Gets or sets the available
        /// </summary>
        [JsonPropertyName("available")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Available
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the minimumFrequency
        /// </summary>
        [JsonPropertyName("minimumFrequency")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? MinimumFrequency
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the maximumFrequency
        /// </summary>
        [JsonPropertyName("maximumFrequency")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? MaximumFrequency
        {
            get;
            set;
        }
    }
}