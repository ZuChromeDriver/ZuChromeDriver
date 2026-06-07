namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class BackForwardCacheBlockingDetails
    {
        /// <summary>
        /// Url of the file where blockage happened. Optional because of tests.
        ///</summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Function name where blockage happened. Optional because of anonymous functions and tests.
        ///</summary>
        [JsonPropertyName("function")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Function
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
    }
}