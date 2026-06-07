namespace Zu.ChromeDevTools.FileSystem
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class File
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
        /// Timestamp
        ///</summary>
        [JsonPropertyName("lastModified")]
        public double LastModified
        {
            get;
            set;
        }
        /// <summary>
        /// Size in bytes
        ///</summary>
        [JsonPropertyName("size")]
        public double Size
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
    }
}