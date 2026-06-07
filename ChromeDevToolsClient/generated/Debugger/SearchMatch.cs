namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Search match for resource.
    /// </summary>
    public sealed class SearchMatch
    {
        /// <summary>
        /// Line number in resource content.
        ///</summary>
        [JsonPropertyName("lineNumber")]
        public double LineNumber
        {
            get;
            set;
        }
        /// <summary>
        /// Line with match content.
        ///</summary>
        [JsonPropertyName("lineContent")]
        public string LineContent
        {
            get;
            set;
        }
    }
}