namespace Zu.ChromeDevTools.DOMDebugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Removes breakpoint from XMLHttpRequest.
    /// </summary>
    public sealed class RemoveXHRBreakpointCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMDebugger.removeXHRBreakpoint";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Resource URL substring.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
    }

    public sealed class RemoveXHRBreakpointCommandResponse : ICommandResponse<RemoveXHRBreakpointCommand>
    {
    }
}