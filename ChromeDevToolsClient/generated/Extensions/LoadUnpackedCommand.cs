namespace Zu.ChromeDevTools.Extensions
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Installs an unpacked extension from the filesystem similar to
    /// --load-extension CLI flags. Returns extension ID once the extension
    /// has been installed.
    /// </summary>
    public sealed class LoadUnpackedCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Extensions.loadUnpacked";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Absolute file path.
        /// </summary>
        [JsonPropertyName("path")]
        public string Path
        {
            get;
            set;
        }
        /// <summary>
        /// Enable the extension in incognito
        /// </summary>
        [JsonPropertyName("enableInIncognito")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? EnableInIncognito
        {
            get;
            set;
        }
    }

    public sealed class LoadUnpackedCommandResponse : ICommandResponse<LoadUnpackedCommand>
    {
        /// <summary>
        /// Extension id.
        ///</summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
    }
}