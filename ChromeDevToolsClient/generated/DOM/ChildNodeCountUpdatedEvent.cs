namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when `Container`'s child node count has changed.
    /// </summary>
    public sealed class ChildNodeCountUpdatedEvent : IEvent
    {
        /// <summary>
        /// Id of the node that has changed.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// New node count.
        /// </summary>
        [JsonPropertyName("childNodeCount")]
        public long ChildNodeCount
        {
            get;
            set;
        }
    }
}