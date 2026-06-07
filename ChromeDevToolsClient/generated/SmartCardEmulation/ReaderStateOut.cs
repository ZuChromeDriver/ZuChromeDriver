namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ReaderStateOut
    {
        /// <summary>
        /// Gets or sets the reader
        /// </summary>
        [JsonPropertyName("reader")]
        public string Reader
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the eventState
        /// </summary>
        [JsonPropertyName("eventState")]
        public ReaderStateFlags EventState
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the eventCount
        /// </summary>
        [JsonPropertyName("eventCount")]
        public long EventCount
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the atr
        /// </summary>
        [JsonPropertyName("atr")]
        public string Atr
        {
            get;
            set;
        }
    }
}