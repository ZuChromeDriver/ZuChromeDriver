namespace Zu.ChromeDevTools.Extensions
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Detailed information about an extension.
    /// </summary>
    public sealed class ExtensionInfo
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
        /// <summary>
        /// Extension name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Extension version.
        ///</summary>
        [JsonPropertyName("version")]
        public string Version
        {
            get;
            set;
        }
        /// <summary>
        /// The path from which the extension was loaded.
        ///</summary>
        [JsonPropertyName("path")]
        public string Path
        {
            get;
            set;
        }
        /// <summary>
        /// Extension enabled status.
        ///</summary>
        [JsonPropertyName("enabled")]
        public bool Enabled
        {
            get;
            set;
        }
    }
}