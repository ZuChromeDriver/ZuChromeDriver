namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns attributes for the specified node.
    /// </summary>
    public sealed class GetAttributesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getAttributes";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node to retrieve attributes for.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }

    public sealed class GetAttributesCommandResponse : ICommandResponse<GetAttributesCommand>
    {
        /// <summary>
        /// An interleaved array of node attribute names and values.
        ///</summary>
        [JsonPropertyName("attributes")]
        public string[] Attributes
        {
            get;
            set;
        }
    }
}