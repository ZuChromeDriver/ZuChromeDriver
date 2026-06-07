namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns storage key for the given frame. If no frame ID is provided,
    /// the storage key of the target executing this command is returned.
    /// </summary>
    public sealed class GetStorageKeyCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.getStorageKey";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the frameId
        /// </summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FrameId
        {
            get;
            set;
        }
    }

    public sealed class GetStorageKeyCommandResponse : ICommandResponse<GetStorageKeyCommand>
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