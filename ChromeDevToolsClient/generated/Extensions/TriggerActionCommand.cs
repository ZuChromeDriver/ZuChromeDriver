namespace Zu.ChromeDevTools.Extensions
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Runs an extension default action.
    /// </summary>
    public sealed class TriggerActionCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Extensions.triggerAction";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Extension id.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// A tab target ID to trigger the default extension action on.
        /// </summary>
        [JsonPropertyName("targetId")]
        public string TargetId
        {
            get;
            set;
        }
    }

    public sealed class TriggerActionCommandResponse : ICommandResponse<TriggerActionCommand>
    {
    }
}