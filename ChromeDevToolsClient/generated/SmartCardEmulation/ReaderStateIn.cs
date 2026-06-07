namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ReaderStateIn
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
        /// Gets or sets the currentState
        /// </summary>
        [JsonPropertyName("currentState")]
        public ReaderStateFlags CurrentState
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the currentInsertionCount
        /// </summary>
        [JsonPropertyName("currentInsertionCount")]
        public long CurrentInsertionCount
        {
            get;
            set;
        }
    }
}