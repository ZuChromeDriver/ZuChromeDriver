namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Set tracking for a storage key's buckets.
    /// </summary>
    public sealed class SetStorageBucketTrackingCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.setStorageBucketTracking";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the storageKey
        /// </summary>
        [JsonPropertyName("storageKey")]
        public string StorageKey
        {
            get;
            set;
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

    public sealed class SetStorageBucketTrackingCommandResponse : ICommandResponse<SetStorageBucketTrackingCommand>
    {
    }
}