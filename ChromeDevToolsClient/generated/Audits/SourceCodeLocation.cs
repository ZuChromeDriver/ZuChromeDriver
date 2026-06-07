namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SourceCodeLocation
    {
        /// <summary>
        /// Gets or sets the scriptId
        /// </summary>
        [JsonPropertyName("scriptId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ScriptId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the lineNumber
        /// </summary>
        [JsonPropertyName("lineNumber")]
        public long LineNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the columnNumber
        /// </summary>
        [JsonPropertyName("columnNumber")]
        public long ColumnNumber
        {
            get;
            set;
        }
    }
}