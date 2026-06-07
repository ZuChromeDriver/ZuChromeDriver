namespace Zu.ChromeDevTools.Extensions
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Uninstalls an unpacked extension (others not supported) from the profile.
    /// </summary>
    public sealed class UninstallCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Extensions.uninstall";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Extension id.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
    }

    public sealed class UninstallCommandResponse : ICommandResponse<UninstallCommand>
    {
    }
}