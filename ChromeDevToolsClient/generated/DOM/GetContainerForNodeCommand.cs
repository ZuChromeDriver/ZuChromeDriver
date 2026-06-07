namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the query container of the given node based on container query
    /// conditions: containerName, physical and logical axes, and whether it queries
    /// scroll-state or anchored elements. If no axes are provided and
    /// queriesScrollState is false, the style container is returned, which is the
    /// direct parent or the closest element with a matching container-name.
    /// </summary>
    public sealed class GetContainerForNodeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getContainerForNode";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the nodeId
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the containerName
        /// </summary>
        [JsonPropertyName("containerName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ContainerName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the physicalAxes
        /// </summary>
        [JsonPropertyName("physicalAxes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PhysicalAxes? PhysicalAxes
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the logicalAxes
        /// </summary>
        [JsonPropertyName("logicalAxes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public LogicalAxes? LogicalAxes
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the queriesScrollState
        /// </summary>
        [JsonPropertyName("queriesScrollState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? QueriesScrollState
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the queriesAnchored
        /// </summary>
        [JsonPropertyName("queriesAnchored")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? QueriesAnchored
        {
            get;
            set;
        }
    }

    public sealed class GetContainerForNodeCommandResponse : ICommandResponse<GetContainerForNodeCommand>
    {
        /// <summary>
        /// The container node for the given node, or null if not found.
        ///</summary>
        [JsonPropertyName("nodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? NodeId
        {
            get;
            set;
        }
    }
}