namespace Zu.ChromeDevTools.HeapProfiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sampling profile.
    /// </summary>
    public sealed class SamplingHeapProfile
    {
        /// <summary>
        /// Gets or sets the head
        /// </summary>
        [JsonPropertyName("head")]
        public SamplingHeapProfileNode Head
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the samples
        /// </summary>
        [JsonPropertyName("samples")]
        public SamplingHeapProfileSample[] Samples
        {
            get;
            set;
        }
    }
}