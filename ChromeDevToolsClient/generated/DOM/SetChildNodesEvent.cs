namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when backend wants to provide client with the missing DOM structure. This happens upon
    /// most of the calls requesting node ids.
    /// </summary>
    public sealed class SetChildNodesEvent : IEvent
    {
        /// <summary>
        /// Parent node id to populate with children.
        /// </summary>
        [JsonPropertyName("parentId")]
        public long ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// Child nodes array.
        /// </summary>
        [JsonPropertyName("nodes")]
        public Node[] Nodes
        {
            get;
            set;
        }
    }
}