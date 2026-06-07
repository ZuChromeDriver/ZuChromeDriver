namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Configuration data for the highlighting of page elements.
    /// </summary>
    public sealed class HighlightConfig
    {
        /// <summary>
        /// Whether the node info tooltip should be shown (default: false).
        ///</summary>
        [JsonPropertyName("showInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowInfo
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the node styles in the tooltip (default: false).
        ///</summary>
        [JsonPropertyName("showStyles")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowStyles
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the rulers should be shown (default: false).
        ///</summary>
        [JsonPropertyName("showRulers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowRulers
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the a11y info should be shown (default: true).
        ///</summary>
        [JsonPropertyName("showAccessibilityInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowAccessibilityInfo
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the extension lines from node to the rulers should be shown (default: false).
        ///</summary>
        [JsonPropertyName("showExtensionLines")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowExtensionLines
        {
            get;
            set;
        }
        /// <summary>
        /// The content box highlight fill color (default: transparent).
        ///</summary>
        [JsonPropertyName("contentColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA ContentColor
        {
            get;
            set;
        }
        /// <summary>
        /// The padding highlight fill color (default: transparent).
        ///</summary>
        [JsonPropertyName("paddingColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA PaddingColor
        {
            get;
            set;
        }
        /// <summary>
        /// The border highlight fill color (default: transparent).
        ///</summary>
        [JsonPropertyName("borderColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA BorderColor
        {
            get;
            set;
        }
        /// <summary>
        /// The margin highlight fill color (default: transparent).
        ///</summary>
        [JsonPropertyName("marginColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA MarginColor
        {
            get;
            set;
        }
        /// <summary>
        /// The event target element highlight fill color (default: transparent).
        ///</summary>
        [JsonPropertyName("eventTargetColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA EventTargetColor
        {
            get;
            set;
        }
        /// <summary>
        /// The shape outside fill color (default: transparent).
        ///</summary>
        [JsonPropertyName("shapeColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA ShapeColor
        {
            get;
            set;
        }
        /// <summary>
        /// The shape margin fill color (default: transparent).
        ///</summary>
        [JsonPropertyName("shapeMarginColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA ShapeMarginColor
        {
            get;
            set;
        }
        /// <summary>
        /// The grid layout color (default: transparent).
        ///</summary>
        [JsonPropertyName("cssGridColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA CssGridColor
        {
            get;
            set;
        }
        /// <summary>
        /// The color format used to format color styles (default: hex).
        ///</summary>
        [JsonPropertyName("colorFormat")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ColorFormat? ColorFormat
        {
            get;
            set;
        }
        /// <summary>
        /// The grid layout highlight configuration (default: all transparent).
        ///</summary>
        [JsonPropertyName("gridHighlightConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public GridHighlightConfig GridHighlightConfig
        {
            get;
            set;
        }
        /// <summary>
        /// The flex container highlight configuration (default: all transparent).
        ///</summary>
        [JsonPropertyName("flexContainerHighlightConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FlexContainerHighlightConfig FlexContainerHighlightConfig
        {
            get;
            set;
        }
        /// <summary>
        /// The flex item highlight configuration (default: all transparent).
        ///</summary>
        [JsonPropertyName("flexItemHighlightConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FlexItemHighlightConfig FlexItemHighlightConfig
        {
            get;
            set;
        }
        /// <summary>
        /// The contrast algorithm to use for the contrast ratio (default: aa).
        ///</summary>
        [JsonPropertyName("contrastAlgorithm")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ContrastAlgorithm? ContrastAlgorithm
        {
            get;
            set;
        }
        /// <summary>
        /// The container query container highlight configuration (default: all transparent).
        ///</summary>
        [JsonPropertyName("containerQueryContainerHighlightConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ContainerQueryContainerHighlightConfig ContainerQueryContainerHighlightConfig
        {
            get;
            set;
        }
    }
}