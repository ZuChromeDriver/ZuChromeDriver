namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Scrolls the specified rect of the given node into view if not already visible.
    /// Note: exactly one between nodeId, backendNodeId and objectId should be passed
    /// to identify the node.
    /// </summary>
    public sealed class ScrollIntoViewIfNeededCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.scrollIntoViewIfNeeded";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the node.
        /// </summary>
        [JsonPropertyName("nodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the backend node.
        /// </summary>
        [JsonPropertyName("backendNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BackendNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// JavaScript object id of the node wrapper.
        /// </summary>
        [JsonPropertyName("objectId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectId
        {
            get;
            set;
        }
        /// <summary>
        /// The rect to be scrolled into view, relative to the node's border box, in CSS pixels.
        /// When omitted, center of the node will be used, similar to Element.scrollIntoView.
        /// </summary>
        [JsonPropertyName("rect")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Rect Rect
        {
            get;
            set;
        }
    }

    public sealed class ScrollIntoViewIfNeededCommandResponse : ICommandResponse<ScrollIntoViewIfNeededCommand>
    {
    }
}