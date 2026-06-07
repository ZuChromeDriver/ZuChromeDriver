namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Mirrors `DOMNodeRemoved` event.
    /// </summary>
    public sealed class ChildNodeRemovedEvent : IEvent
    {
        /// <summary>
        /// Parent id.
        /// </summary>
        [JsonPropertyName("parentNodeId")]
        public long ParentNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Id of the node that has been removed.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }
}