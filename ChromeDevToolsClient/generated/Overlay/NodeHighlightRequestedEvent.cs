namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when the node should be highlighted. This happens after call to `setInspectMode`.
    /// </summary>
    public sealed class NodeHighlightRequestedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the nodeId
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }
}