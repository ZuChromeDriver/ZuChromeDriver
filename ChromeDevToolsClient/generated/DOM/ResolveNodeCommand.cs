namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Resolves the JavaScript node object for a given NodeId or BackendNodeId.
    /// </summary>
    public sealed class ResolveNodeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.resolveNode";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node to resolve.
        /// </summary>
        [JsonPropertyName("nodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Backend identifier of the node to resolve.
        /// </summary>
        [JsonPropertyName("backendNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BackendNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Symbolic group name that can be used to release multiple objects.
        /// </summary>
        [JsonPropertyName("objectGroup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectGroup
        {
            get;
            set;
        }
        /// <summary>
        /// Execution context in which to resolve the node.
        /// </summary>
        [JsonPropertyName("executionContextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ExecutionContextId
        {
            get;
            set;
        }
    }

    public sealed class ResolveNodeCommandResponse : ICommandResponse<ResolveNodeCommand>
    {
        /// <summary>
        /// JavaScript object wrapper for given node.
        ///</summary>
        [JsonPropertyName("object")]
        public Runtime.RemoteObject Object
        {
            get;
            set;
        }
    }
}