namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns node's HTML markup.
    /// </summary>
    public sealed class GetOuterHTMLCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getOuterHTML";
        
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
        /// Include all shadow roots. Equals to false if not specified.
        /// </summary>
        [JsonPropertyName("includeShadowDOM")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludeShadowDOM
        {
            get;
            set;
        }
    }

    public sealed class GetOuterHTMLCommandResponse : ICommandResponse<GetOuterHTMLCommand>
    {
        /// <summary>
        /// Outer HTML markup.
        ///</summary>
        [JsonPropertyName("outerHTML")]
        public string OuterHTML
        {
            get;
            set;
        }
    }
}