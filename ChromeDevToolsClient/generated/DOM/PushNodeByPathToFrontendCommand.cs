namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Requests that the node is sent to the caller given its path. // FIXME, use XPath
    /// </summary>
    public sealed class PushNodeByPathToFrontendCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.pushNodeByPathToFrontend";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Path to node in the proprietary format.
        /// </summary>
        [JsonPropertyName("path")]
        public string Path
        {
            get;
            set;
        }
    }

    public sealed class PushNodeByPathToFrontendCommandResponse : ICommandResponse<PushNodeByPathToFrontendCommand>
    {
        /// <summary>
        /// Id of the node for given path.
        ///</summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }
}