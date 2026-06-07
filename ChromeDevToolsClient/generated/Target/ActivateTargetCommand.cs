namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Activates (focuses) the target.
    /// </summary>
    public sealed class ActivateTargetCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Target.activateTarget";
        
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

    public sealed class ActivateTargetCommandResponse : ICommandResponse<ActivateTargetCommand>
    {
    }
}