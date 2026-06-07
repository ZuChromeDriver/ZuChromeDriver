namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SetProtectedAudienceKAnonymityCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.setProtectedAudienceKAnonymity";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the owner
        /// </summary>
        [JsonPropertyName("owner")]
        public string Owner
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the hashes
        /// </summary>
        [JsonPropertyName("hashes")]
        public string[] Hashes
        {
            get;
            set;
        }
    }

    public sealed class SetProtectedAudienceKAnonymityCommandResponse : ICommandResponse<SetProtectedAudienceKAnonymityCommand>
    {
    }
}