namespace Zu.ChromeDevTools.CacheStorage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Deletes a cache entry.
    /// </summary>
    public sealed class DeleteEntryCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CacheStorage.deleteEntry";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of cache where the entry will be deleted.
        /// </summary>
        [JsonPropertyName("cacheId")]
        public string CacheId
        {
            get;
            set;
        }
        /// <summary>
        /// URL spec of the request.
        /// </summary>
        [JsonPropertyName("request")]
        public string Request
        {
            get;
            set;
        }
    }

    public sealed class DeleteEntryCommandResponse : ICommandResponse<DeleteEntryCommand>
    {
    }
}