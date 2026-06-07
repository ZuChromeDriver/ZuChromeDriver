namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Detaches session with given id.
    /// </summary>
    public sealed class DetachFromTargetCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Target.detachFromTarget";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Session to detach.
        /// </summary>
        [JsonPropertyName("sessionId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SessionId
        {
            get;
            set;
        }
        /// <summary>
        /// Deprecated.
        /// </summary>
        [JsonPropertyName("targetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TargetId
        {
            get;
            set;
        }
    }

    public sealed class DetachFromTargetCommandResponse : ICommandResponse<DetachFromTargetCommand>
    {
    }
}