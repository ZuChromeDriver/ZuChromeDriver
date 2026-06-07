namespace Zu.ChromeDevTools.DOMDebugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets breakpoint on particular DOM event.
    /// </summary>
    public sealed class SetEventListenerBreakpointCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMDebugger.setEventListenerBreakpoint";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// DOM Event name to stop on (any DOM event will do).
        /// </summary>
        [JsonPropertyName("eventName")]
        public string EventName
        {
            get;
            set;
        }
        /// <summary>
        /// EventTarget interface name to stop on. If equal to `"*"` or not provided, will stop on any
        /// EventTarget.
        /// </summary>
        [JsonPropertyName("targetName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TargetName
        {
            get;
            set;
        }
    }

    public sealed class SetEventListenerBreakpointCommandResponse : ICommandResponse<SetEventListenerBreakpointCommand>
    {
    }
}