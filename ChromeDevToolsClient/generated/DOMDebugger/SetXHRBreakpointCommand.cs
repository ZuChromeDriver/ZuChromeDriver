namespace Zu.ChromeDevTools.DOMDebugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets breakpoint on XMLHttpRequest.
    /// </summary>
    public sealed class SetXHRBreakpointCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMDebugger.setXHRBreakpoint";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Resource URL substring. All XHRs having this substring in the URL will get stopped upon.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
    }

    public sealed class SetXHRBreakpointCommandResponse : ICommandResponse<SetXHRBreakpointCommand>
    {
    }
}