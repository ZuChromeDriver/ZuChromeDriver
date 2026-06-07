namespace Zu.ChromeDevTools.DOMDebugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets breakpoint on particular operation with DOM.
    /// </summary>
    public sealed class SetDOMBreakpointCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMDebugger.setDOMBreakpoint";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the node to set breakpoint on.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Type of the operation to stop upon.
        /// </summary>
        [JsonPropertyName("type")]
        public DOMBreakpointType Type
        {
            get;
            set;
        }
    }

    public sealed class SetDOMBreakpointCommandResponse : ICommandResponse<SetDOMBreakpointCommand>
    {
    }
}