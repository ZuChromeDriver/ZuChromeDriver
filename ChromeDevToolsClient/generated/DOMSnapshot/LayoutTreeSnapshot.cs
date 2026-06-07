namespace Zu.ChromeDevTools.DOMSnapshot
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Table of details of an element in the DOM tree with a LayoutObject.
    /// </summary>
    public sealed class LayoutTreeSnapshot
    {
        /// <summary>
        /// Index of the corresponding node in the `NodeTreeSnapshot` array returned by `captureSnapshot`.
        ///</summary>
        [JsonPropertyName("nodeIndex")]
        public long[] NodeIndex
        {
            get;
            set;
        }
        /// <summary>
        /// Array of indexes specifying computed style strings, filtered according to the `computedStyles` parameter passed to `captureSnapshot`.
        ///</summary>
        [JsonPropertyName("styles")]
        public long[][] Styles
        {
            get;
            set;
        }
        /// <summary>
        /// The absolute position bounding box.
        ///</summary>
        [JsonPropertyName("bounds")]
        public double[][] Bounds
        {
            get;
            set;
        }
        /// <summary>
        /// Contents of the LayoutText, if any.
        ///</summary>
        [JsonPropertyName("text")]
        public long[] Text
        {
            get;
            set;
        }
        /// <summary>
        /// Stacking context information.
        ///</summary>
        [JsonPropertyName("stackingContexts")]
        public RareBooleanData StackingContexts
        {
            get;
            set;
        }
        /// <summary>
        /// Global paint order index, which is determined by the stacking order of the nodes. Nodes
        /// that are painted together will have the same index. Only provided if includePaintOrder in
        /// captureSnapshot was true.
        ///</summary>
        [JsonPropertyName("paintOrders")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[] PaintOrders
        {
            get;
            set;
        }
        /// <summary>
        /// The offset rect of nodes. Only available when includeDOMRects is set to true
        ///</summary>
        [JsonPropertyName("offsetRects")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double[][] OffsetRects
        {
            get;
            set;
        }
        /// <summary>
        /// The scroll rect of nodes. Only available when includeDOMRects is set to true
        ///</summary>
        [JsonPropertyName("scrollRects")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double[][] ScrollRects
        {
            get;
            set;
        }
        /// <summary>
        /// The client rect of nodes. Only available when includeDOMRects is set to true
        ///</summary>
        [JsonPropertyName("clientRects")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double[][] ClientRects
        {
            get;
            set;
        }
        /// <summary>
        /// The list of background colors that are blended with colors of overlapping elements.
        ///</summary>
        [JsonPropertyName("blendedBackgroundColors")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[] BlendedBackgroundColors
        {
            get;
            set;
        }
        /// <summary>
        /// The list of computed text opacities.
        ///</summary>
        [JsonPropertyName("textColorOpacities")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double[] TextColorOpacities
        {
            get;
            set;
        }
    }
}