namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS rule representation.
    /// </summary>
    public sealed class CSSRule
    {
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
        /// Rule selector data.
        ///</summary>
        [JsonPropertyName("selectorList")]
        public SelectorList SelectorList
        {
            get;
            set;
        }
        /// <summary>
        /// Array of selectors from ancestor style rules, sorted by distance from the current rule.
        ///</summary>
        [JsonPropertyName("nestingSelectors")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] NestingSelectors
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
        /// The BackendNodeId of the DOM node that constitutes the origin tree scope of this rule.
        ///</summary>
        [JsonPropertyName("originTreeScopeNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? OriginTreeScopeNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Media list array (for rules involving media queries). The array enumerates media queries
        /// starting with the innermost one, going outwards.
        ///</summary>
        [JsonPropertyName("media")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSMedia[] Media
        {
            get;
            set;
        }
        /// <summary>
        /// Container query list array (for rules involving container queries).
        /// The array enumerates container queries starting with the innermost one, going outwards.
        ///</summary>
        [JsonPropertyName("containerQueries")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSContainerQuery[] ContainerQueries
        {
            get;
            set;
        }
        /// <summary>
        /// @supports CSS at-rule array.
        /// The array enumerates @supports at-rules starting with the innermost one, going outwards.
        ///</summary>
        [JsonPropertyName("supports")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSSupports[] Supports
        {
            get;
            set;
        }
        /// <summary>
        /// Cascade layer array. Contains the layer hierarchy that this rule belongs to starting
        /// with the innermost layer and going outwards.
        ///</summary>
        [JsonPropertyName("layers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSLayer[] Layers
        {
            get;
            set;
        }
        /// <summary>
        /// @scope CSS at-rule array.
        /// The array enumerates @scope at-rules starting with the innermost one, going outwards.
        ///</summary>
        [JsonPropertyName("scopes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSScope[] Scopes
        {
            get;
            set;
        }
        /// <summary>
        /// The array keeps the types of ancestor CSSRules from the innermost going outwards.
        ///</summary>
        [JsonPropertyName("ruleTypes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSRuleType[] RuleTypes
        {
            get;
            set;
        }
        /// <summary>
        /// @starting-style CSS at-rule array.
        /// The array enumerates @starting-style at-rules starting with the innermost one, going outwards.
        ///</summary>
        [JsonPropertyName("startingStyles")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSStartingStyle[] StartingStyles
        {
            get;
            set;
        }
        /// <summary>
        /// @navigation CSS at-rule array.
        /// The array enumerates @navigation at-rules starting with the innermost one, going outwards.
        ///</summary>
        [JsonPropertyName("navigations")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSNavigation[] Navigations
        {
            get;
            set;
        }
    }
}