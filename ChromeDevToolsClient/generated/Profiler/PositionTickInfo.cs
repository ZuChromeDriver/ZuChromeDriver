namespace Zu.ChromeDevTools.Profiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Specifies a number of samples attributed to a certain source position.
    /// </summary>
    public sealed class PositionTickInfo
    {
        /// <summary>
        /// Source line number (1-based).
        ///</summary>
        [JsonPropertyName("line")]
        public long Line
        {
            get;
            set;
        }
        /// <summary>
        /// Number of samples attributed to the source line.
        ///</summary>
        [JsonPropertyName("ticks")]
        public long Ticks
        {
            get;
            set;
        }
    }
}