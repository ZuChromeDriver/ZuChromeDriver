namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A descriptor of operation to mutate style declaration text.
    /// </summary>
    public sealed class StyleDeclarationEdit
    {
        /// <summary>
        /// The css style sheet identifier.
        ///</summary>
        [JsonPropertyName("styleSheetId")]
        public string StyleSheetId
        {
            get;
            set;
        }
        /// <summary>
        /// The range of the style text in the enclosing stylesheet.
        ///</summary>
        [JsonPropertyName("range")]
        public SourceRange Range
        {
            get;
            set;
        }
        /// <summary>
        /// New style text.
        ///</summary>
        [JsonPropertyName("text")]
        public string Text
        {
            get;
            set;
        }
    }
}