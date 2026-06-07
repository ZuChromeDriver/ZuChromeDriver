namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets JavaScript breakpoint before each call to the given function.
    /// If another function was created from the same source as a given one,
    /// calling it will also trigger the breakpoint.
    /// </summary>
    public sealed class SetBreakpointOnFunctionCallCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.setBreakpointOnFunctionCall";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Function object id.
        /// </summary>
        [JsonPropertyName("objectId")]
        public string ObjectId
        {
            get;
            set;
        }
        /// <summary>
        /// Expression to use as a breakpoint condition. When specified, debugger will
        /// stop on the breakpoint if this expression evaluates to true.
        /// </summary>
        [JsonPropertyName("condition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Condition
        {
            get;
            set;
        }
    }

    public sealed class SetBreakpointOnFunctionCallCommandResponse : ICommandResponse<SetBreakpointOnFunctionCallCommand>
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