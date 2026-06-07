namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the root DOM node (and optionally the subtree) to the caller.
    /// Implicitly enables the DOM domain events for the current target.
    /// </summary>
    public sealed class GetDocumentCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getDocument";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The maximum depth at which children should be retrieved, defaults to 1. Use -1 for the
        /// entire subtree or provide an integer larger than 0.
        /// </summary>
        [JsonPropertyName("depth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Depth
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not iframes and shadow roots should be traversed when returning the subtree
        /// (default is false).
        /// </summary>
        [JsonPropertyName("pierce")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Pierce
        {
            get;
            set;
        }
    }

    public sealed class GetDocumentCommandResponse : ICommandResponse<GetDocumentCommand>
    {
        /// <summary>
        /// Resulting node.
        ///</summary>
        [JsonPropertyName("root")]
        public Node Root
        {
            get;
            set;
        }
    }
}