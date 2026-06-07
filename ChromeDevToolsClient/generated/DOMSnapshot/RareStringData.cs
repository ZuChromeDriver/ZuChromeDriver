namespace Zu.ChromeDevTools.DOMSnapshot
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Data that is only present on rare nodes.
    /// </summary>
    public sealed class RareStringData
    {
        /// <summary>
        /// Gets or sets the index
        /// </summary>
        [JsonPropertyName("index")]
        public long[] Index
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        [JsonPropertyName("value")]
        public long[] Value
        {
            get;
            set;
        }
    }
}