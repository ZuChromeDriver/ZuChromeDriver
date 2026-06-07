namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Gets the targetId of the DevTools page target opened for the given target
    /// (if any).
    /// </summary>
    public sealed class GetDevToolsTargetCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Target.getDevToolsTarget";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Page or tab target ID.
        /// </summary>
        [JsonPropertyName("targetId")]
        public string TargetId
        {
            get;
            set;
        }
    }

    public sealed class GetDevToolsTargetCommandResponse : ICommandResponse<GetDevToolsTargetCommand>
    {
        /// <summary>
        /// The targetId of DevTools page target if exists.
        ///</summary>
        [JsonPropertyName("targetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TargetId
        {
            get;
            set;
        }
    }
}