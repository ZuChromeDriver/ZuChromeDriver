namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns requested styles for a DOM node identified by `nodeId`.
    /// </summary>
    public sealed class GetMatchedStylesForNodeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.getMatchedStylesForNode";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the nodeId
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }

    public sealed class GetMatchedStylesForNodeCommandResponse : ICommandResponse<GetMatchedStylesForNodeCommand>
    {
        /// <summary>
        /// Inline style for the specified DOM node.
        ///</summary>
        [JsonPropertyName("inlineStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSStyle InlineStyle
        {
            get;
            set;
        }
        /// <summary>
        /// Attribute-defined element style (e.g. resulting from "width=20 height=100%").
        ///</summary>
        [JsonPropertyName("attributesStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSStyle AttributesStyle
        {
            get;
            set;
        }
        /// <summary>
        /// CSS rules matching this node, from all applicable stylesheets.
        ///</summary>
        [JsonPropertyName("matchedCSSRules")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RuleMatch[] MatchedCSSRules
        {
            get;
            set;
        }
        /// <summary>
        /// Pseudo style matches for this node.
        ///</summary>
        [JsonPropertyName("pseudoElements")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PseudoElementMatches[] PseudoElements
        {
            get;
            set;
        }
        /// <summary>
        /// A chain of inherited styles (from the immediate node parent up to the DOM tree root).
        ///</summary>
        [JsonPropertyName("inherited")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public InheritedStyleEntry[] Inherited
        {
            get;
            set;
        }
        /// <summary>
        /// A chain of inherited pseudo element styles (from the immediate node parent up to the DOM tree root).
        ///</summary>
        [JsonPropertyName("inheritedPseudoElements")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public InheritedPseudoElementMatches[] InheritedPseudoElements
        {
            get;
            set;
        }
        /// <summary>
        /// A list of CSS keyframed animations matching this node.
        ///</summary>
        [JsonPropertyName("cssKeyframesRules")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSKeyframesRule[] CssKeyframesRules
        {
            get;
            set;
        }
        /// <summary>
        /// A list of CSS @position-try rules matching this node, based on the position-try-fallbacks property.
        ///</summary>
        [JsonPropertyName("cssPositionTryRules")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSPositionTryRule[] CssPositionTryRules
        {
            get;
            set;
        }
        /// <summary>
        /// Index of the active fallback in the applied position-try-fallback property,
        /// will not be set if there is no active position-try fallback.
        ///</summary>
        [JsonPropertyName("activePositionFallbackIndex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ActivePositionFallbackIndex
        {
            get;
            set;
        }
        /// <summary>
        /// A list of CSS at-property rules matching this node.
        ///</summary>
        [JsonPropertyName("cssPropertyRules")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSPropertyRule[] CssPropertyRules
        {
            get;
            set;
        }
        /// <summary>
        /// A list of CSS property registrations matching this node.
        ///</summary>
        [JsonPropertyName("cssPropertyRegistrations")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSPropertyRegistration[] CssPropertyRegistrations
        {
            get;
            set;
        }
        /// <summary>
        /// A list of simple @rules matching this node or its pseudo-elements.
        ///</summary>
        [JsonPropertyName("cssAtRules")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSAtRule[] CssAtRules
        {
            get;
            set;
        }
        /// <summary>
        /// Id of the first parent element that does not have display: contents.
        ///</summary>
        [JsonPropertyName("parentLayoutNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ParentLayoutNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// A list of CSS at-function rules referenced by styles of this node.
        ///</summary>
        [JsonPropertyName("cssFunctionRules")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSFunctionRule[] CssFunctionRules
        {
            get;
            set;
        }
    }
}