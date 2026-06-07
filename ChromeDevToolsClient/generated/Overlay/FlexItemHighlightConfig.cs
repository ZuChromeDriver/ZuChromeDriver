namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Configuration data for the highlighting of Flex item elements.
    /// </summary>
    public sealed class FlexItemHighlightConfig
    {
        /// <summary>
        /// Style of the box representing the item's base size
        ///</summary>
        [JsonPropertyName("baseSizeBox")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public BoxStyle BaseSizeBox
        {
            get;
            set;
        }
        /// <summary>
        /// Style of the border around the box representing the item's base size
        ///</summary>
        [JsonPropertyName("baseSizeBorder")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public LineStyle BaseSizeBorder
        {
            get;
            set;
        }
        /// <summary>
        /// Style of the arrow representing if the item grew or shrank
        ///</summary>
        [JsonPropertyName("flexibilityArrow")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public LineStyle FlexibilityArrow
        {
            get;
            set;
        }
    }
}