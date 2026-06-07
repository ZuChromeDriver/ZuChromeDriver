namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns stack trace with given `stackTraceId`.
    /// </summary>
    public sealed class GetStackTraceCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.getStackTrace";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the stackTraceId
        /// </summary>
        [JsonPropertyName("stackTraceId")]
        public Runtime.StackTraceId StackTraceId
        {
            get;
            set;
        }
    }

    public sealed class GetStackTraceCommandResponse : ICommandResponse<GetStackTraceCommand>
    {
        /// <summary>
        /// Gets or sets the stackTrace
        /// </summary>
        [JsonPropertyName("stackTrace")]
        public Runtime.StackTrace StackTrace
        {
            get;
            set;
        }
    }
}