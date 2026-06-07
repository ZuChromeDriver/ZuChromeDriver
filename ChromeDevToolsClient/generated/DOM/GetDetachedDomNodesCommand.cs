namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns list of detached nodes
    /// </summary>
    public sealed class GetDetachedDomNodesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getDetachedDomNodes";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetDetachedDomNodesCommandResponse : ICommandResponse<GetDetachedDomNodesCommand>
    {
        /// <summary>
        /// The list of detached nodes
        ///</summary>
        [JsonPropertyName("detachedNodes")]
        public DetachedElementInfo[] DetachedNodes
        {
            get;
            set;
        }
    }
}