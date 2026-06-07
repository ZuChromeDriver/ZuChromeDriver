namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Called when distribution is changed.
    /// </summary>
    public sealed class DistributedNodesUpdatedEvent : IEvent
    {
        /// <summary>
        /// Insertion point where distributed nodes were updated.
        /// </summary>
        [JsonPropertyName("insertionPointId")]
        public long InsertionPointId
        {
            get;
            set;
        }
        /// <summary>
        /// Distributed nodes for given insertion point.
        /// </summary>
        [JsonPropertyName("distributedNodes")]
        public BackendNode[] DistributedNodes
        {
            get;
            set;
        }
    }
}