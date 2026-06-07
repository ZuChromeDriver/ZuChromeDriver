namespace Zu.ChromeDevTools.PWA
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the following OS state for the given manifest id.
    /// </summary>
    public sealed class GetOsAppStateCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "PWA.getOsAppState";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The id from the webapp's manifest file, commonly it's the url of the
        /// site installing the webapp. See
        /// https://web.dev/learn/pwa/web-app-manifest.
        /// </summary>
        [JsonPropertyName("manifestId")]
        public string ManifestId
        {
            get;
            set;
        }
    }

    public sealed class GetOsAppStateCommandResponse : ICommandResponse<GetOsAppStateCommand>
    {
        /// <summary>
        /// Gets or sets the badgeCount
        /// </summary>
        [JsonPropertyName("badgeCount")]
        public long BadgeCount
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the fileHandlers
        /// </summary>
        [JsonPropertyName("fileHandlers")]
        public FileHandler[] FileHandlers
        {
            get;
            set;
        }
    }
}