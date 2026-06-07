namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS Layer at-rule descriptor.
    /// </summary>
    public sealed class CSSLayer
    {
        /// <summary>
        /// Layer name.
        ///</summary>
        [JsonPropertyName("text")]
        public string Text
        {
            get;
            set;
        }
        /// <summary>
        /// The associated rule header range in the enclosing stylesheet (if
        /// available).
        ///</summary>
        [JsonPropertyName("range")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SourceRange Range
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the stylesheet containing this object (if exists).
        ///</summary>
        [JsonPropertyName("styleSheetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string StyleSheetId
        {
            get;
            set;
        }
    }
}