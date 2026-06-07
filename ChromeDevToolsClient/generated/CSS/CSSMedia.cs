namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS media rule descriptor.
    /// </summary>
    public sealed class CSSMedia
    {
        /// <summary>
        /// Media query text.
        ///</summary>
        [JsonPropertyName("text")]
        public string Text
        {
            get;
            set;
        }
        /// <summary>
        /// Source of the media query: "mediaRule" if specified by a @media rule, "importRule" if
        /// specified by an @import rule, "linkedSheet" if specified by a "media" attribute in a linked
        /// stylesheet's LINK tag, "inlineSheet" if specified by a "media" attribute in an inline
        /// stylesheet's STYLE tag.
        ///</summary>
        [JsonPropertyName("source")]
        public string Source
        {
            get;
            set;
        }
        /// <summary>
        /// URL of the document containing the media query description.
        ///</summary>
        [JsonPropertyName("sourceURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SourceURL
        {
            get;
            set;
        }
        /// <summary>
        /// The associated rule (@media or @import) header range in the enclosing stylesheet (if
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
        /// <summary>
        /// Array of media queries.
        ///</summary>
        [JsonPropertyName("mediaList")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public MediaQuery[] MediaList
        {
            get;
            set;
        }
    }
}