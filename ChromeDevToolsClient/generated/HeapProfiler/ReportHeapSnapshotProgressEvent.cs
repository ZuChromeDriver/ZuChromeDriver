namespace Zu.ChromeDevTools.HeapProfiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ReportHeapSnapshotProgressEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the done
        /// </summary>
        [JsonPropertyName("done")]
        public long Done
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the total
        /// </summary>
        [JsonPropertyName("total")]
        public long Total
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the finished
        /// </summary>
        [JsonPropertyName("finished")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Finished
        {
            get;
            set;
        }
    }
}