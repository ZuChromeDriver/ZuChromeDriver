namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets attribute for an element with given id.
    /// </summary>
    public sealed class SetAttributeValueCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.setAttributeValue";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the element to set attribute for.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Attribute name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Attribute value.
        /// </summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
    }

    public sealed class SetAttributeValueCommandResponse : ICommandResponse<SetAttributeValueCommand>
    {
    }
}