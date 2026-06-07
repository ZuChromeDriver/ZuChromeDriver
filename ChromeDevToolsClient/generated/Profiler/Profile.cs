namespace Zu.ChromeDevTools.Profiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Profile.
    /// </summary>
    public sealed class Profile
    {
        /// <summary>
        /// The list of profile nodes. First item is the root node.
        ///</summary>
        [JsonPropertyName("nodes")]
        public ProfileNode[] Nodes
        {
            get;
            set;
        }
        /// <summary>
        /// Profiling start timestamp in microseconds.
        ///</summary>
        [JsonPropertyName("startTime")]
        public double StartTime
        {
            get;
            set;
        }
        /// <summary>
        /// Profiling end timestamp in microseconds.
        ///</summary>
        [JsonPropertyName("endTime")]
        public double EndTime
        {
            get;
            set;
        }
        /// <summary>
        /// Ids of samples top nodes.
        ///</summary>
        [JsonPropertyName("samples")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[] Samples
        {
            get;
            set;
        }
        /// <summary>
        /// Time intervals between adjacent samples in microseconds. The first delta is relative to the
        /// profile startTime.
        ///</summary>
        [JsonPropertyName("timeDeltas")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[] TimeDeltas
        {
            get;
            set;
        }
    }
}