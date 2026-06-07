namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets instrumentation breakpoint.
    /// </summary>
    public sealed class SetInstrumentationBreakpointCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.setInstrumentationBreakpoint";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Instrumentation name.
        /// </summary>
        [JsonPropertyName("instrumentation")]
        public string Instrumentation
        {
            get;
            set;
        }
    }

    public sealed class SetInstrumentationBreakpointCommandResponse : ICommandResponse<SetInstrumentationBreakpointCommand>
    {
        /// <summary>
        /// Id of the created breakpoint for further reference.
        ///</summary>
        [JsonPropertyName("breakpointId")]
        public string BreakpointId
        {
            get;
            set;
        }
    }
}