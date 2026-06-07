namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns a storage key given a frame id.
    /// Deprecated. Please use Storage.getStorageKey instead.
    /// </summary>
    public sealed class GetStorageKeyForFrameCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.getStorageKeyForFrame";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the frameId
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
    }

    public sealed class GetStorageKeyForFrameCommandResponse : ICommandResponse<GetStorageKeyForFrameCommand>
    {
        /// <summary>
        /// Gets or sets the storageKey
        /// </summary>
        [JsonPropertyName("storageKey")]
        public string StorageKey
        {
            get;
            set;
        }
    }
}