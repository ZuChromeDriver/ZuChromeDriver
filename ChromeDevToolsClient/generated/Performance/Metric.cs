namespace Zu.ChromeDevTools.Performance
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Run-time execution metric.
    /// </summary>
    public sealed class Metric
    {
        /// <summary>
        /// Metric name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Metric value.
        ///</summary>
        [JsonPropertyName("value")]
        public double Value
        {
            get;
            set;
        }
    }
}