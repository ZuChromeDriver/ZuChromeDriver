namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Configuration data for drawing the source order of an elements children.
    /// </summary>
    public sealed class SourceOrderConfig
    {
        /// <summary>
        /// the color to outline the given element in.
        ///</summary>
        [JsonPropertyName("parentOutlineColor")]
        public DOM.RGBA ParentOutlineColor
        {
            get;
            set;
        }
        /// <summary>
        /// the color to outline the child elements in.
        ///</summary>
        [JsonPropertyName("childOutlineColor")]
        public DOM.RGBA ChildOutlineColor
        {
            get;
            set;
        }
    }
}