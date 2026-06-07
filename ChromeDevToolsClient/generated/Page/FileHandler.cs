namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class FileHandler
    {
        /// <summary>
        /// Gets or sets the action
        /// </summary>
        [JsonPropertyName("action")]
        public string Action
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
        /// Gets or sets the icons
        /// </summary>
        [JsonPropertyName("icons")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ImageResource[] Icons
        {
            get;
            set;
        }
        /// <summary>
        /// Mimic a map, name is the key, accepts is the value.
        ///</summary>
        [JsonPropertyName("accepts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FileFilter[] Accepts
        {
            get;
            set;
        }
        /// <summary>
        /// Won't repeat the enums, using string for easy comparison. Same as the
        /// other enums below.
        ///</summary>
        [JsonPropertyName("launchType")]
        public string LaunchType
        {
            get;
            set;
        }
    }
}