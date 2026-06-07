namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fetches the root node.
    /// Requires `enable()` to have been called previously.
    /// </summary>
    public sealed class GetRootAXNodeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Accessibility.getRootAXNode";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The frame in whose document the node resides.
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

    public sealed class GetRootAXNodeCommandResponse : ICommandResponse<GetRootAXNodeCommand>
    {
        /// <summary>
        /// Gets or sets the node
        /// </summary>
        [JsonPropertyName("node")]
        public AXNode Node
        {
            get;
            set;
        }
    }
}