namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets JavaScript breakpoint at a given location.
    /// </summary>
    public sealed class SetBreakpointCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.setBreakpoint";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Location to set breakpoint in.
        /// </summary>
        [JsonPropertyName("location")]
        public Location Location
        {
            get;
            set;
        }
        /// <summary>
        /// Expression to use as a breakpoint condition. When specified, debugger will only stop on the
        /// breakpoint if this expression evaluates to true.
        /// </summary>
        [JsonPropertyName("condition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Condition
        {
            get;
            set;
        }
    }

    public sealed class SetBreakpointCommandResponse : ICommandResponse<SetBreakpointCommand>
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
        /// <summary>
        /// Location this breakpoint resolved into.
        ///</summary>
        [JsonPropertyName("actualLocation")]
        public Location ActualLocation
        {
            get;
            set;
        }
    }
}