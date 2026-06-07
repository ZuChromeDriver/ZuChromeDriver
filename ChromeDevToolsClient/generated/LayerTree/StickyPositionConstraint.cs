namespace Zu.ChromeDevTools.LayerTree
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sticky position constraints.
    /// </summary>
    public sealed class StickyPositionConstraint
    {
        /// <summary>
        /// Layout rectangle of the sticky element before being shifted
        ///</summary>
        [JsonPropertyName("stickyBoxRect")]
        public DOM.Rect StickyBoxRect
        {
            get;
            set;
        }
        /// <summary>
        /// Layout rectangle of the containing block of the sticky element
        ///</summary>
        [JsonPropertyName("containingBlockRect")]
        public DOM.Rect ContainingBlockRect
        {
            get;
            set;
        }
        /// <summary>
        /// The nearest sticky layer that shifts the sticky box
        ///</summary>
        [JsonPropertyName("nearestLayerShiftingStickyBox")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string NearestLayerShiftingStickyBox
        {
            get;
            set;
        }
        /// <summary>
        /// The nearest sticky layer that shifts the containing block
        ///</summary>
        [JsonPropertyName("nearestLayerShiftingContainingBlock")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string NearestLayerShiftingContainingBlock
        {
            get;
            set;
        }
    }
}