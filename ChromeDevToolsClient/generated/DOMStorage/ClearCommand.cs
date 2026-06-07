namespace Zu.ChromeDevTools.DOMStorage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ClearCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMStorage.clear";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the storageId
        /// </summary>
        [JsonPropertyName("storageId")]
        public StorageId StorageId
        {
            get;
            set;
        }
    }

    public sealed class ClearCommandResponse : ICommandResponse<ClearCommand>
    {
    }
}