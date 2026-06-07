namespace Zu.ChromeDevTools.LayerTree
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class LayerPaintedEvent : IEvent
    {
        /// <summary>
        /// The id of the painted layer.
        /// </summary>
        [JsonPropertyName("layerId")]
        public string LayerId
        {
            get;
            set;
        }
        /// <summary>
        /// Clip rectangle.
        /// </summary>
        [JsonPropertyName("clip")]
        public DOM.Rect Clip
        {
            get;
            set;
        }
    }
}