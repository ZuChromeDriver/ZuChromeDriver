namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enables/disables issuing of sharedStorageAccessed events.
    /// </summary>
    public sealed class SetSharedStorageTrackingCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.setSharedStorageTracking";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the enable
        /// </summary>
        [JsonPropertyName("enable")]
        public bool Enable
        {
            get;
            set;
        }
    }

    public sealed class SetSharedStorageTrackingCommandResponse : ICommandResponse<SetSharedStorageTrackingCommand>
    {
    }
}