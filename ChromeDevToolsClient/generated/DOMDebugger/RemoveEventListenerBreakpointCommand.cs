namespace Zu.ChromeDevTools.DOMDebugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Removes breakpoint on particular DOM event.
    /// </summary>
    public sealed class RemoveEventListenerBreakpointCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMDebugger.removeEventListenerBreakpoint";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Event name.
        /// </summary>
        [JsonPropertyName("eventName")]
        public string EventName
        {
            get;
            set;
        }
        /// <summary>
        /// EventTarget interface name.
        /// </summary>
        [JsonPropertyName("targetName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TargetName
        {
            get;
            set;
        }
    }

    public sealed class RemoveEventListenerBreakpointCommandResponse : ICommandResponse<RemoveEventListenerBreakpointCommand>
    {
    }
}