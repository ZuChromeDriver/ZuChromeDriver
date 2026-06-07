namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Unregisters origin from receiving notifications for cache storage.
    /// </summary>
    public sealed class UntrackCacheStorageForOriginCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.untrackCacheStorageForOrigin";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Security origin.
        /// </summary>
        [JsonPropertyName("origin")]
        public string Origin
        {
            get;
            set;
        }
    }

    public sealed class UntrackCacheStorageForOriginCommandResponse : ICommandResponse<UntrackCacheStorageForOriginCommand>
    {
    }
}