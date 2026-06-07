namespace Zu.ChromeDevTools.Tracing
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Signals that tracing is stopped and there is no trace buffers pending flush, all data were
    /// delivered via dataCollected events.
    /// </summary>
    public sealed class TracingCompleteEvent : IEvent
    {
        /// <summary>
        /// Indicates whether some trace data is known to have been lost, e.g. because the trace ring
        /// buffer wrapped around.
        /// </summary>
        [JsonPropertyName("dataLossOccurred")]
        public bool DataLossOccurred
        {
            get;
            set;
        }
        /// <summary>
        /// A handle of the stream that holds resulting trace data.
        /// </summary>
        [JsonPropertyName("stream")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Stream
        {
            get;
            set;
        }
        /// <summary>
        /// Trace data format of returned stream.
        /// </summary>
        [JsonPropertyName("traceFormat")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public StreamFormat? TraceFormat
        {
            get;
            set;
        }
        /// <summary>
        /// Compression format of returned stream.
        /// </summary>
        [JsonPropertyName("streamCompression")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public StreamCompression? StreamCompression
        {
            get;
            set;
        }
    }
}