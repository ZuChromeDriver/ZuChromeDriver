namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Layout viewport position and dimensions.
    /// </summary>
    public sealed class LayoutViewport
    {
        /// <summary>
        /// Horizontal offset relative to the document (CSS pixels).
        ///</summary>
        [JsonPropertyName("pageX")]
        public long PageX
        {
            get;
            set;
        }
        /// <summary>
        /// Vertical offset relative to the document (CSS pixels).
        ///</summary>
        [JsonPropertyName("pageY")]
        public long PageY
        {
            get;
            set;
        }
        /// <summary>
        /// Width (CSS pixels), excludes scrollbar if present.
        ///</summary>
        [JsonPropertyName("clientWidth")]
        public long ClientWidth
        {
            get;
            set;
        }
        /// <summary>
        /// Height (CSS pixels), excludes scrollbar if present.
        ///</summary>
        [JsonPropertyName("clientHeight")]
        public long ClientHeight
        {
            get;
            set;
        }
    }
}