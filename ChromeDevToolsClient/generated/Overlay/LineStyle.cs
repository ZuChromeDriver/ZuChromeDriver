namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Style information for drawing a line.
    /// </summary>
    public sealed class LineStyle
    {
        /// <summary>
        /// The color of the line (default: transparent)
        ///</summary>
        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA Color
        {
            get;
            set;
        }
        /// <summary>
        /// The line pattern (default: solid)
        ///</summary>
        [JsonPropertyName("pattern")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Pattern
        {
            get;
            set;
        }
    }
}