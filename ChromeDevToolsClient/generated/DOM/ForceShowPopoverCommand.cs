namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// When enabling, this API force-opens the popover identified by nodeId
    /// and keeps it open until disabled.
    /// </summary>
    public sealed class ForceShowPopoverCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.forceShowPopover";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the popover HTMLElement
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// If true, opens the popover and keeps it open. If false, closes the
        /// popover if it was previously force-opened.
        /// </summary>
        [JsonPropertyName("enable")]
        public bool Enable
        {
            get;
            set;
        }
    }

    public sealed class ForceShowPopoverCommandResponse : ICommandResponse<ForceShowPopoverCommand>
    {
        /// <summary>
        /// List of popovers that were closed in order to respect popover stacking order.
        ///</summary>
        [JsonPropertyName("nodeIds")]
        public long[] NodeIds
        {
            get;
            set;
        }
    }
}