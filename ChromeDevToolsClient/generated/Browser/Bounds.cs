namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Browser window bounds information
    /// </summary>
    public sealed class Bounds
    {
        /// <summary>
        /// The offset from the left edge of the screen to the window in pixels.
        ///</summary>
        [JsonPropertyName("left")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Left
        {
            get;
            set;
        }
        /// <summary>
        /// The offset from the top edge of the screen to the window in pixels.
        ///</summary>
        [JsonPropertyName("top")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Top
        {
            get;
            set;
        }
        /// <summary>
        /// The window width in pixels.
        ///</summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Width
        {
            get;
            set;
        }
        /// <summary>
        /// The window height in pixels.
        ///</summary>
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Height
        {
            get;
            set;
        }
        /// <summary>
        /// The window state. Default to normal.
        ///</summary>
        [JsonPropertyName("windowState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public WindowState? WindowState
        {
            get;
            set;
        }
    }
}