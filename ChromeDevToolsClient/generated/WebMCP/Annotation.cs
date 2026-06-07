namespace Zu.ChromeDevTools.WebMCP
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Tool annotations
    /// </summary>
    public sealed class Annotation
    {
        /// <summary>
        /// A hint indicating that the tool does not modify any state.
        ///</summary>
        [JsonPropertyName("readOnly")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ReadOnly
        {
            get;
            set;
        }
        /// <summary>
        /// A hint indicating that the tool output may contain untrusted content, ex: UGC, 3rd party data.
        ///</summary>
        [JsonPropertyName("untrustedContent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? UntrustedContent
        {
            get;
            set;
        }
        /// <summary>
        /// If the declarative tool was declared with the autosubmit attribute.
        ///</summary>
        [JsonPropertyName("autosubmit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Autosubmit
        {
            get;
            set;
        }
    }
}