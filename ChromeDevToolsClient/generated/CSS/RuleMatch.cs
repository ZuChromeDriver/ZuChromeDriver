namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Match data for a CSS rule.
    /// </summary>
    public sealed class RuleMatch
    {
        /// <summary>
        /// CSS rule in the match.
        ///</summary>
        [JsonPropertyName("rule")]
        public CSSRule Rule
        {
            get;
            set;
        }
        /// <summary>
        /// Matching selector indices in the rule's selectorList selectors (0-based).
        ///</summary>
        [JsonPropertyName("matchingSelectors")]
        public long[] MatchingSelectors
        {
            get;
            set;
        }
    }
}