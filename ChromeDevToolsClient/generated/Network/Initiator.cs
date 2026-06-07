namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about the request initiator.
    /// </summary>
    public sealed class Initiator
    {
        /// <summary>
        /// Type of this initiator.
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
        /// <summary>
        /// Initiator JavaScript stack trace, set for Script only.
        /// Requires the Debugger domain to be enabled.
        ///</summary>
        [JsonPropertyName("stack")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.StackTrace Stack
        {
            get;
            set;
        }
        /// <summary>
        /// Initiator URL, set for Parser type or for Script type (when script is importing module) or for SignedExchange type.
        ///</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Initiator line number, set for Parser type or for Script type (when script is importing
        /// module) (0-based).
        ///</summary>
        [JsonPropertyName("lineNumber")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? LineNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Initiator column number, set for Parser type or for Script type (when script is importing
        /// module) (0-based).
        ///</summary>
        [JsonPropertyName("columnNumber")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? ColumnNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Set if another request triggered this request (e.g. preflight).
        ///</summary>
        [JsonPropertyName("requestId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RequestId
        {
            get;
            set;
        }
    }
}