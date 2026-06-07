namespace Zu.ChromeDevTools.SystemInfo
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents process info.
    /// </summary>
    public sealed class ProcessInfo
    {
        /// <summary>
        /// Specifies process type.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies process id.
        ///</summary>
        [JsonPropertyName("id")]
        public long Id
        {
            get;
            set;
        }
        /// <summary>
        /// Specifies cumulative CPU usage in seconds across all threads of the
        /// process since the process start.
        ///</summary>
        [JsonPropertyName("cpuTime")]
        public double CpuTime
        {
            get;
            set;
        }
    }
}