namespace Zu.ChromeDevTools.LayerTree
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Rectangle where scrolling happens on the main thread.
    /// </summary>
    public sealed class ScrollRect
    {
        /// <summary>
        /// Rectangle itself.
        ///</summary>
        [JsonPropertyName("rect")]
        public DOM.Rect Rect
        {
            get;
            set;
        }
        /// <summary>
        /// Reason for rectangle to force scrolling on the main thread
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
    }
}