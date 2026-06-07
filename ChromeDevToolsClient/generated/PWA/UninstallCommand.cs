namespace Zu.ChromeDevTools.PWA
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Uninstalls the given manifest_id and closes any opened app windows.
    /// </summary>
    public sealed class UninstallCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "PWA.uninstall";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the manifestId
        /// </summary>
        [JsonPropertyName("manifestId")]
        public string ManifestId
        {
            get;
            set;
        }
    }

    public sealed class UninstallCommandResponse : ICommandResponse<UninstallCommand>
    {
    }
}