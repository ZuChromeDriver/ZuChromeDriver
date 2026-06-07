namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Defines pause on exceptions state. Can be set to stop on all exceptions, uncaught exceptions,
    /// or caught exceptions, no exceptions. Initial pause on exceptions state is `none`.
    /// </summary>
    public sealed class SetPauseOnExceptionsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.setPauseOnExceptions";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Pause on exceptions mode.
        /// </summary>
        [JsonPropertyName("state")]
        public string State
        {
            get;
            set;
        }
    }

    public sealed class SetPauseOnExceptionsCommandResponse : ICommandResponse<SetPauseOnExceptionsCommand>
    {
    }
}