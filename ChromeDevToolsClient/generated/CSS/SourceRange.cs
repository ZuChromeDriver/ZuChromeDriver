namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Text range within a resource. All numbers are zero-based.
    /// </summary>
    public sealed class SourceRange
    {
        /// <summary>
        /// Start line of range.
        ///</summary>
        [JsonPropertyName("startLine")]
        public long StartLine
        {
            get;
            set;
        }
        /// <summary>
        /// Start column of range (inclusive).
        ///</summary>
        [JsonPropertyName("startColumn")]
        public long StartColumn
        {
            get;
            set;
        }
        /// <summary>
        /// End line of range
        ///</summary>
        [JsonPropertyName("endLine")]
        public long EndLine
        {
            get;
            set;
        }
        /// <summary>
        /// End column of range (exclusive).
        ///</summary>
        [JsonPropertyName("endColumn")]
        public long EndColumn
        {
            get;
            set;
        }
    }
}