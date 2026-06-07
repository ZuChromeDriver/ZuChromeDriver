namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Mirrors `DOMNodeInserted` event.
    /// </summary>
    public sealed class ChildNodeInsertedEvent : IEvent
    {
        /// <summary>
        /// Id of the node that has changed.
        /// </summary>
        [JsonPropertyName("parentNodeId")]
        public long ParentNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Id of the previous sibling.
        /// </summary>
        [JsonPropertyName("previousNodeId")]
        public long PreviousNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Inserted node data.
        /// </summary>
        [JsonPropertyName("node")]
        public Node Node
        {
            get;
            set;
        }
    }
}