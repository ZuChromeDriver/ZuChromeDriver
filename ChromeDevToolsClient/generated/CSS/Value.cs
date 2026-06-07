namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Data for a simple selector (these are delimited by commas in a selector list).
    /// </summary>
    public sealed class Value
    {
        /// <summary>
        /// Value text.
        ///</summary>
        [JsonPropertyName("text")]
        public string Text
        {
            get;
            set;
        }
        /// <summary>
        /// Value range in the underlying resource (if available).
        ///</summary>
        [JsonPropertyName("range")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SourceRange Range
        {
            get;
            set;
        }
        /// <summary>
        /// Specificity of the selector.
        ///</summary>
        [JsonPropertyName("specificity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Specificity Specificity
        {
            get;
            set;
        }
    }
}