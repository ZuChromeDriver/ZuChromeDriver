namespace Zu.ChromeDevTools.DOMDebugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Object event listener.
    /// </summary>
    public sealed class EventListener
    {
        /// <summary>
        /// `EventListener`'s type.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// `EventListener`'s useCapture.
        ///</summary>
        [JsonPropertyName("useCapture")]
        public bool UseCapture
        {
            get;
            set;
        }
        /// <summary>
        /// `EventListener`'s passive flag.
        ///</summary>
        [JsonPropertyName("passive")]
        public bool Passive
        {
            get;
            set;
        }
        /// <summary>
        /// `EventListener`'s once flag.
        ///</summary>
        [JsonPropertyName("once")]
        public bool Once
        {
            get;
            set;
        }
        /// <summary>
        /// Script id of the handler code.
        ///</summary>
        [JsonPropertyName("scriptId")]
        public string ScriptId
        {
            get;
            set;
        }
        /// <summary>
        /// Line number in the script (0-based).
        ///</summary>
        [JsonPropertyName("lineNumber")]
        public long LineNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Column number in the script (0-based).
        ///</summary>
        [JsonPropertyName("columnNumber")]
        public long ColumnNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Event handler function value.
        ///</summary>
        [JsonPropertyName("handler")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.RemoteObject Handler
        {
            get;
            set;
        }
        /// <summary>
        /// Event original handler function value.
        ///</summary>
        [JsonPropertyName("originalHandler")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.RemoteObject OriginalHandler
        {
            get;
            set;
        }
        /// <summary>
        /// Node the listener is added to (if any).
        ///</summary>
        [JsonPropertyName("backendNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BackendNodeId
        {
            get;
            set;
        }
    }
}