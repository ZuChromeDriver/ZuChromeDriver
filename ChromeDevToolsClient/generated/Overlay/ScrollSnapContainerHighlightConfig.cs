namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ScrollSnapContainerHighlightConfig
    {
        /// <summary>
        /// The style of the snapport border (default: transparent)
        ///</summary>
        [JsonPropertyName("snapportBorder")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public LineStyle SnapportBorder
        {
            get;
            set;
        }
        /// <summary>
        /// The style of the snap area border (default: transparent)
        ///</summary>
        [JsonPropertyName("snapAreaBorder")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public LineStyle SnapAreaBorder
        {
            get;
            set;
        }
        /// <summary>
        /// The margin highlight fill color (default: transparent).
        ///</summary>
        [JsonPropertyName("scrollMarginColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA ScrollMarginColor
        {
            get;
            set;
        }
        /// <summary>
        /// The padding highlight fill color (default: transparent).
        ///</summary>
        [JsonPropertyName("scrollPaddingColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA ScrollPaddingColor
        {
            get;
            set;
        }
    }
}