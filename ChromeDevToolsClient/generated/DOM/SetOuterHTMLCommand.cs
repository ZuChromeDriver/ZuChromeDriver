namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets node HTML markup, returns new node id.
    /// </summary>
    public sealed class SetOuterHTMLCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.setOuterHTML";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node to set markup for.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Outer HTML markup to set.
        /// </summary>
        [JsonPropertyName("outerHTML")]
        public string OuterHTML
        {
            get;
            set;
        }
    }

    public sealed class SetOuterHTMLCommandResponse : ICommandResponse<SetOuterHTMLCommand>
    {
    }
}