namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS rule collection for a single pseudo style.
    /// </summary>
    public sealed class PseudoElementMatches
    {
        /// <summary>
        /// Pseudo element type.
        ///</summary>
        [JsonPropertyName("pseudoType")]
        public DOM.PseudoType PseudoType
        {
            get;
            set;
        }
        /// <summary>
        /// Pseudo element custom ident.
        ///</summary>
        [JsonPropertyName("pseudoIdentifier")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PseudoIdentifier
        {
            get;
            set;
        }
        /// <summary>
        /// Matches of CSS rules applicable to the pseudo style.
        ///</summary>
        [JsonPropertyName("matches")]
        public RuleMatch[] Matches
        {
            get;
            set;
        }
    }
}