namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Tells inspected instance to run if it was waiting for debugger to attach.
    /// </summary>
    public sealed class RunIfWaitingForDebuggerCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Runtime.runIfWaitingForDebugger";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class RunIfWaitingForDebuggerCommandResponse : ICommandResponse<RunIfWaitingForDebuggerCommand>
    {
    }
}