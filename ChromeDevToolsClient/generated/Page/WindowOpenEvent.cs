namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when a new window is going to be opened, via window.open(), link click, form submission,
    /// etc.
    /// </summary>
    public sealed class WindowOpenEvent : IEvent
    {
        /// <summary>
        /// The URL for the new window.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Window name.
        /// </summary>
        [JsonPropertyName("windowName")]
        public string WindowName
        {
            get;
            set;
        }
        /// <summary>
        /// An array of enabled window features.
        /// </summary>
        [JsonPropertyName("windowFeatures")]
        public string[] WindowFeatures
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not it was triggered by user gesture.
        /// </summary>
        [JsonPropertyName("userGesture")]
        public bool UserGesture
        {
            get;
            set;
        }
    }
}