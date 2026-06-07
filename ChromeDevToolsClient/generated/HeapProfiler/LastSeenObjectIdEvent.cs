namespace Zu.ChromeDevTools.HeapProfiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// If heap objects tracking has been started then backend regularly sends a current value for last
    /// seen object id and corresponding timestamp. If the were changes in the heap since last event
    /// then one or more heapStatsUpdate events will be sent before a new lastSeenObjectId event.
    /// </summary>
    public sealed class LastSeenObjectIdEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the lastSeenObjectId
        /// </summary>
        [JsonPropertyName("lastSeenObjectId")]
        public long LastSeenObjectId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the timestamp
        /// </summary>
        [JsonPropertyName("timestamp")]
        public double Timestamp
        {
            get;
            set;
        }
    }
}