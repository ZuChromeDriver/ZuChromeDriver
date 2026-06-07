namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the NodeId of the matched element according to certain relations.
    /// </summary>
    public sealed class GetElementByRelationCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getElementByRelation";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node from which to query the relation.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Type of relation to get.
        /// </summary>
        [JsonPropertyName("relation")]
        public string Relation
        {
            get;
            set;
        }
    }

    public sealed class GetElementByRelationCommandResponse : ICommandResponse<GetElementByRelationCommand>
    {
        /// <summary>
        /// NodeId of the element matching the queried relation.
        ///</summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }
}