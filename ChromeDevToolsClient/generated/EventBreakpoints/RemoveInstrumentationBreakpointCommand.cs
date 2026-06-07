namespace Zu.ChromeDevTools.EventBreakpoints
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Removes breakpoint on particular native event.
    /// </summary>
    public sealed class RemoveInstrumentationBreakpointCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "EventBreakpoints.removeInstrumentationBreakpoint";
        
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

    public sealed class RemoveInstrumentationBreakpointCommandResponse : ICommandResponse<RemoveInstrumentationBreakpointCommand>
    {
    }
}