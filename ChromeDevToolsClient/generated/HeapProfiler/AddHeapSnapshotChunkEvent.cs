namespace Zu.ChromeDevTools.HeapProfiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class AddHeapSnapshotChunkEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the chunk
        /// </summary>
        [JsonPropertyName("chunk")]
        public string Chunk
        {
            get;
            set;
        }
    }
}