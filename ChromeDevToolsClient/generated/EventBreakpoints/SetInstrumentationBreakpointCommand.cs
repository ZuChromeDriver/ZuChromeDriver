namespace Zu.ChromeDevTools.EventBreakpoints
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets breakpoint on particular native event.
    /// </summary>
    public sealed class SetInstrumentationBreakpointCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "EventBreakpoints.setInstrumentationBreakpoint";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Instrumentation name to stop on.
        /// </summary>
        [JsonPropertyName("eventName")]
        public string EventName
        {
            get;
            set;
        }
    }

    public sealed class SetInstrumentationBreakpointCommandResponse : ICommandResponse<SetInstrumentationBreakpointCommand>
    {
    }
}