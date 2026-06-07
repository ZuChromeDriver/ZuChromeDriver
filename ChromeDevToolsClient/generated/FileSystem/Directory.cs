namespace Zu.ChromeDevTools.FileSystem
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class Directory
    {
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
        /// Gets or sets the nestedDirectories
        /// </summary>
        [JsonPropertyName("nestedDirectories")]
        public string[] NestedDirectories
        {
            get;
            set;
        }
        /// <summary>
        /// Files that are directly nested under this directory.
        ///</summary>
        [JsonPropertyName("nestedFiles")]
        public File[] NestedFiles
        {
            get;
            set;
        }
    }
}