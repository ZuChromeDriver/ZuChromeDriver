namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS @position-try rule representation.
    /// </summary>
    public sealed class CSSPositionTryRule
    {
        /// <summary>
        /// The prelude dashed-ident name
        ///</summary>
        [JsonPropertyName("name")]
        public Value Name
        {
            get;
            set;
        }
        /// <summary>
        /// The css style sheet identifier (absent for user agent stylesheet and user-specified
        /// stylesheet rules) this rule came from.
        ///</summary>
        [JsonPropertyName("styleSheetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string StyleSheetId
        {
            get;
            set;
        }
        /// <summary>
        /// Parent stylesheet's origin.
        ///</summary>
        [JsonPropertyName("origin")]
        public StyleSheetOrigin Origin
        {
            get;
            set;
        }
        /// <summary>
        /// Associated style declaration.
        ///</summary>
        [JsonPropertyName("style")]
        public CSSStyle Style
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the active
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active
        {
            get;
            set;
        }
    }
}