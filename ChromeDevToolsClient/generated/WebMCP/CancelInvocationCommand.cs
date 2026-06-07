namespace Zu.ChromeDevTools.WebMCP
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Cancels a pending tool invocation.
    /// </summary>
    public sealed class CancelInvocationCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "WebMCP.cancelInvocation";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Invocation identifier to cancel.
        /// </summary>
        [JsonPropertyName("invocationId")]
        public string InvocationId
        {
            get;
            set;
        }
    }

    public sealed class CancelInvocationCommandResponse : ICommandResponse<CancelInvocationCommand>
    {
    }
}