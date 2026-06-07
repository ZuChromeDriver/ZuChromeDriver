namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class IsolationModeHighlightConfig
    {
        /// <summary>
        /// The fill color of the resizers (default: transparent).
        ///</summary>
        [JsonPropertyName("resizerColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA ResizerColor
        {
            get;
            set;
        }
        /// <summary>
        /// The fill color for resizer handles (default: transparent).
        ///</summary>
        [JsonPropertyName("resizerHandleColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA ResizerHandleColor
        {
            get;
            set;
        }
        /// <summary>
        /// The fill color for the mask covering non-isolated elements (default: transparent).
        ///</summary>
        [JsonPropertyName("maskColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA MaskColor
        {
            get;
            set;
        }
    }
}