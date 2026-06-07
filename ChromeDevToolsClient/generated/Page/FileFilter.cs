namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class FileFilter
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the accepts
        /// </summary>
        [JsonPropertyName("accepts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] Accepts
        {
            get;
            set;
        }
    }
}