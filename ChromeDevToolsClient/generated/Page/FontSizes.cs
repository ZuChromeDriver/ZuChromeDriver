namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Default font sizes.
    /// </summary>
    public sealed class FontSizes
    {
        /// <summary>
        /// Default standard font size.
        ///</summary>
        [JsonPropertyName("standard")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Standard
        {
            get;
            set;
        }
        /// <summary>
        /// Default fixed font size.
        ///</summary>
        [JsonPropertyName("fixed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Fixed
        {
            get;
            set;
        }
    }
}