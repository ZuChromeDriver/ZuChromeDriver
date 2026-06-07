namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Style information for drawing a box.
    /// </summary>
    public sealed class BoxStyle
    {
        /// <summary>
        /// The background color for the box (default: transparent)
        ///</summary>
        [JsonPropertyName("fillColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA FillColor
        {
            get;
            set;
        }
        /// <summary>
        /// The hatching color for the box (default: transparent)
        ///</summary>
        [JsonPropertyName("hatchColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA HatchColor
        {
            get;
            set;
        }
    }
}