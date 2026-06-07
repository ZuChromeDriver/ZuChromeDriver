namespace Zu.ChromeDevTools.DOMDebugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets breakpoint on particular CSP violations.
    /// </summary>
    public sealed class SetBreakOnCSPViolationCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMDebugger.setBreakOnCSPViolation";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// CSP Violations to stop upon.
        /// </summary>
        [JsonPropertyName("violationTypes")]
        public CSPViolationType[] ViolationTypes
        {
            get;
            set;
        }
    }

    public sealed class SetBreakOnCSPViolationCommandResponse : ICommandResponse<SetBreakOnCSPViolationCommand>
    {
    }
}