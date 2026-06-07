namespace Zu.ChromeDevTools.LayerTree
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class LayerTreeDidChangeEvent : IEvent
    {
        /// <summary>
        /// Layer tree, absent if not in the compositing mode.
        /// </summary>
        [JsonPropertyName("layers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Layer[] Layers
        {
            get;
            set;
        }
    }
}