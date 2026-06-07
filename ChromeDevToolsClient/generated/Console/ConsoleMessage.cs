namespace Zu.ChromeDevTools.Console
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Console message.
    /// </summary>
    public sealed class ConsoleMessage
    {
        /// <summary>
        /// Message source.
        ///</summary>
        [JsonPropertyName("source")]
        public string Source
        {
            get;
            set;
        }
        /// <summary>
        /// Message severity.
        ///</summary>
        [JsonPropertyName("level")]
        public string Level
        {
            get;
            set;
        }
        /// <summary>
        /// Message text.
        ///</summary>
        [JsonPropertyName("text")]
        public string Text
        {
            get;
            set;
        }
        /// <summary>
        /// URL of the message origin.
        ///</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Line number in the resource that generated this message (1-based).
        ///</summary>
        [JsonPropertyName("line")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Line
        {
            get;
            set;
        }
        /// <summary>
        /// Column number in the resource that generated this message (1-based).
        ///</summary>
        [JsonPropertyName("column")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Column
        {
            get;
            set;
        }
    }
}