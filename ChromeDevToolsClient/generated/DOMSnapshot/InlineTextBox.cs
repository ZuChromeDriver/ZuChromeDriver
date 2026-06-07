namespace Zu.ChromeDevTools.DOMSnapshot
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Details of post layout rendered text positions. The exact layout should not be regarded as
    /// stable and may change between versions.
    /// </summary>
    public sealed class InlineTextBox
    {
        /// <summary>
        /// The bounding box in document coordinates. Note that scroll offset of the document is ignored.
        ///</summary>
        [JsonPropertyName("boundingBox")]
        public DOM.Rect BoundingBox
        {
            get;
            set;
        }
        /// <summary>
        /// The starting index in characters, for this post layout textbox substring. Characters that
        /// would be represented as a surrogate pair in UTF-16 have length 2.
        ///</summary>
        [JsonPropertyName("startCharacterIndex")]
        public long StartCharacterIndex
        {
            get;
            set;
        }
        /// <summary>
        /// The number of characters in this post layout textbox substring. Characters that would be
        /// represented as a surrogate pair in UTF-16 have length 2.
        ///</summary>
        [JsonPropertyName("numCharacters")]
        public long NumCharacters
        {
            get;
            set;
        }
    }
}