namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fetches the entire accessibility tree for the root Document
    /// </summary>
    public sealed class GetFullAXTreeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Accessibility.getFullAXTree";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The maximum depth at which descendants of the root node should be retrieved.
        /// If omitted, the full tree is returned.
        /// </summary>
        [JsonPropertyName("depth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Depth
        {
            get;
            set;
        }
        /// <summary>
        /// The frame for whose document the AX tree should be retrieved.
        /// If omitted, the root frame is used.
        /// </summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FrameId
        {
            get;
            set;
        }
    }

    public sealed class GetFullAXTreeCommandResponse : ICommandResponse<GetFullAXTreeCommand>
    {
        /// <summary>
        /// Gets or sets the nodes
        /// </summary>
        [JsonPropertyName("nodes")]
        public AXNode[] Nodes
        {
            get;
            set;
        }
    }
}