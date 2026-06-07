namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Configuration for dual screen hinge
    /// </summary>
    public sealed class HingeConfig
    {
        /// <summary>
        /// A rectangle represent hinge
        ///</summary>
        [JsonPropertyName("rect")]
        public DOM.Rect Rect
        {
            get;
            set;
        }
        /// <summary>
        /// The content box highlight fill color (default: a dark color).
        ///</summary>
        [JsonPropertyName("contentColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA ContentColor
        {
            get;
            set;
        }
        /// <summary>
        /// The content box highlight outline color (default: transparent).
        ///</summary>
        [JsonPropertyName("outlineColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA OutlineColor
        {
            get;
            set;
        }
    }
}