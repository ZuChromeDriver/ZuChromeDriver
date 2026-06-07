namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clears storage for origin.
    /// </summary>
    public sealed class ClearDataForOriginCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.clearDataForOrigin";
        
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
        /// <summary>
        /// Comma separated list of StorageType to clear.
        /// </summary>
        [JsonPropertyName("storageTypes")]
        public string StorageTypes
        {
            get;
            set;
        }
    }

    public sealed class ClearDataForOriginCommandResponse : ICommandResponse<ClearDataForOriginCommand>
    {
    }
}