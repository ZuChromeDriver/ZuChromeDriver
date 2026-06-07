namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Navigation history entry.
    /// </summary>
    public sealed class NavigationEntry
    {
        /// <summary>
        /// Unique id of the navigation history entry.
        ///</summary>
        [JsonPropertyName("id")]
        public long Id
        {
            get;
            set;
        }
        /// <summary>
        /// URL of the navigation history entry.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// URL that the user typed in the url bar.
        ///</summary>
        [JsonPropertyName("userTypedURL")]
        public string UserTypedURL
        {
            get;
            set;
        }
        /// <summary>
        /// Title of the navigation history entry.
        ///</summary>
        [JsonPropertyName("title")]
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// Transition type.
        ///</summary>
        [JsonPropertyName("transitionType")]
        public TransitionType TransitionType
        {
            get;
            set;
        }
    }
}