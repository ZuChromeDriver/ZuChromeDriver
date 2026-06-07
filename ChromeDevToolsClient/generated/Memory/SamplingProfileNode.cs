namespace Zu.ChromeDevTools.Memory
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Heap profile sample.
    /// </summary>
    public sealed class SamplingProfileNode
    {
        /// <summary>
        /// Size of the sampled allocation.
        ///</summary>
        [JsonPropertyName("size")]
        public double Size
        {
            get;
            set;
        }
        /// <summary>
        /// Total bytes attributed to this sample.
        ///</summary>
        [JsonPropertyName("total")]
        public double Total
        {
            get;
            set;
        }
        /// <summary>
        /// Execution stack at the point of allocation.
        ///</summary>
        [JsonPropertyName("stack")]
        public string[] Stack
        {
            get;
            set;
        }
    }
}