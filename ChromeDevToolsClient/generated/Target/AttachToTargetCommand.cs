namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Attaches to the target with given id.
    /// </summary>
    public sealed class AttachToTargetCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Target.attachToTarget";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the targetId
        /// </summary>
        [JsonPropertyName("targetId")]
        public string TargetId
        {
            get;
            set;
        }
        /// <summary>
        /// Enables "flat" access to the session via specifying sessionId attribute in the commands.
        /// We plan to make this the default, deprecate non-flattened mode,
        /// and eventually retire it. See crbug.com/991325.
        /// </summary>
        [JsonPropertyName("flatten")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Flatten
        {
            get;
            set;
        }
    }

    public sealed class AttachToTargetCommandResponse : ICommandResponse<AttachToTargetCommand>
    {
        /// <summary>
        /// Id assigned to the session.
        ///</summary>
        [JsonPropertyName("sessionId")]
        public string SessionId
        {
            get;
            set;
        }
    }
}