namespace Zu.ChromeDevTools.DOMSnapshot
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class RareIntegerData
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