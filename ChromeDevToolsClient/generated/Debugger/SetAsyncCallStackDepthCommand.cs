namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enables or disables async call stacks tracking.
    /// </summary>
    public sealed class SetAsyncCallStackDepthCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.setAsyncCallStackDepth";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Maximum depth of async call stacks. Setting to `0` will effectively disable collecting async
        /// call stacks (default).
        /// </summary>
        [JsonPropertyName("maxDepth")]
        public long MaxDepth
        {
            get;
            set;
        }
    }

    public sealed class SetAsyncCallStackDepthCommandResponse : ICommandResponse<SetAsyncCallStackDepthCommand>
    {
    }
}