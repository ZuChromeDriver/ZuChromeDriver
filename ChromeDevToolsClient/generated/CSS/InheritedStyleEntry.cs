namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Inherited CSS rule collection from ancestor node.
    /// </summary>
    public sealed class InheritedStyleEntry
    {
        /// <summary>
        /// The ancestor node's inline style, if any, in the style inheritance chain.
        ///</summary>
        [JsonPropertyName("inlineStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSStyle InlineStyle
        {
            get;
            set;
        }
        /// <summary>
        /// Matches of CSS rules matching the ancestor node in the style inheritance chain.
        ///</summary>
        [JsonPropertyName("matchedCSSRules")]
        public RuleMatch[] MatchedCSSRules
        {
            get;
            set;
        }
    }
}