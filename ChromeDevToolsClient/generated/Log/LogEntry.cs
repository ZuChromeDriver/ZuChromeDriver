namespace Zu.ChromeDevTools.Log
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Log entry.
    /// </summary>
    public sealed class LogEntry
    {
        /// <summary>
        /// Log entry source.
        ///</summary>
        [JsonPropertyName("source")]
        public string Source
        {
            get;
            set;
        }
        /// <summary>
        /// Log entry severity.
        ///</summary>
        [JsonPropertyName("level")]
        public string Level
        {
            get;
            set;
        }
        /// <summary>
        /// Logged text.
        ///</summary>
        [JsonPropertyName("text")]
        public string Text
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the category
        /// </summary>
        [JsonPropertyName("category")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Category
        {
            get;
            set;
        }
        /// <summary>
        /// Timestamp when this entry was added.
        ///</summary>
        [JsonPropertyName("timestamp")]
        public double Timestamp
        {
            get;
            set;
        }
        /// <summary>
        /// URL of the resource if known.
        ///</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Line number in the resource.
        ///</summary>
        [JsonPropertyName("lineNumber")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? LineNumber
        {
            get;
            set;
        }
        /// <summary>
        /// JavaScript stack trace.
        ///</summary>
        [JsonPropertyName("stackTrace")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.StackTrace StackTrace
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the network request associated with this entry.
        ///</summary>
        [JsonPropertyName("networkRequestId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string NetworkRequestId
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the worker associated with this entry.
        ///</summary>
        [JsonPropertyName("workerId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string WorkerId
        {
            get;
            set;
        }
        /// <summary>
        /// Call arguments.
        ///</summary>
        [JsonPropertyName("args")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.RemoteObject[] Args
        {
            get;
            set;
        }
    }
}