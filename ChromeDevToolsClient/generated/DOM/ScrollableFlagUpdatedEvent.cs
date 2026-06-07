namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when a node's scrollability state changes.
    /// </summary>
    public sealed class ScrollableFlagUpdatedEvent : IEvent
    {
        /// <summary>
        /// The id of the node.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// If the node is scrollable.
        /// </summary>
        [JsonPropertyName("isScrollable")]
        public bool IsScrollable
        {
            get;
            set;
        }
    }
}