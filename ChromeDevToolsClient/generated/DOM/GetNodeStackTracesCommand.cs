namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Gets stack traces associated with a Node. As of now, only provides stack trace for Node creation.
    /// </summary>
    public sealed class GetNodeStackTracesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getNodeStackTraces";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node to get stack traces for.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }

    public sealed class GetNodeStackTracesCommandResponse : ICommandResponse<GetNodeStackTracesCommand>
    {
        /// <summary>
        /// Creation stack trace, if available.
        ///</summary>
        [JsonPropertyName("creation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.StackTrace Creation
        {
            get;
            set;
        }
    }
}