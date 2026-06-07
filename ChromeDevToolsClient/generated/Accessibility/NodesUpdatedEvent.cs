namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The nodesUpdated event is sent every time a previously requested node has changed the in tree.
    /// </summary>
    public sealed class NodesUpdatedEvent : IEvent
    {
        /// <summary>
        /// Updated node data.
        /// </summary>
        [JsonPropertyName("nodes")]
        public AXNode[] Nodes
        {
            get;
            set;
        }
    }
}