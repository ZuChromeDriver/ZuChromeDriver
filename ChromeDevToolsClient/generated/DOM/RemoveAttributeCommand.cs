namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Removes attribute with given name from an element with given id.
    /// </summary>
    public sealed class RemoveAttributeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.removeAttribute";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the element to remove attribute from.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Name of the attribute to remove.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
    }

    public sealed class RemoveAttributeCommandResponse : ICommandResponse<RemoveAttributeCommand>
    {
    }
}