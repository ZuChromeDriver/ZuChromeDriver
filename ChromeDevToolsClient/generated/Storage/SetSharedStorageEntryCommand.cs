namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets entry with `key` and `value` for a given origin's shared storage.
    /// </summary>
    public sealed class SetSharedStorageEntryCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.setSharedStorageEntry";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the ownerOrigin
        /// </summary>
        [JsonPropertyName("ownerOrigin")]
        public string OwnerOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
        /// <summary>
        /// If `ignoreIfPresent` is included and true, then only sets the entry if
        /// `key` doesn't already exist.
        /// </summary>
        [JsonPropertyName("ignoreIfPresent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IgnoreIfPresent
        {
            get;
            set;
        }
    }

    public sealed class SetSharedStorageEntryCommandResponse : ICommandResponse<SetSharedStorageEntryCommand>
    {
    }
}