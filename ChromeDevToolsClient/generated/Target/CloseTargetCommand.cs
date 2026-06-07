namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Closes the target. If the target is a page that gets closed too.
    /// </summary>
    public sealed class CloseTargetCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Target.closeTarget";
        
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
    }

    public sealed class CloseTargetCommandResponse : ICommandResponse<CloseTargetCommand>
    {
        /// <summary>
        /// Always set to true. If an error occurs, the response indicates protocol error.
        ///</summary>
        [JsonPropertyName("success")]
        public bool Success
        {
            get;
            set;
        }
    }
}