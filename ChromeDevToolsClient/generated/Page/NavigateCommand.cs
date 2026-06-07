namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Navigates current page to the given URL.
    /// </summary>
    public sealed class NavigateCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.navigate";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// URL to navigate the page to.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Referrer URL.
        /// </summary>
        [JsonPropertyName("referrer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Referrer
        {
            get;
            set;
        }
        /// <summary>
        /// Intended transition type.
        /// </summary>
        [JsonPropertyName("transitionType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TransitionType? TransitionType
        {
            get;
            set;
        }
        /// <summary>
        /// Frame id to navigate, if not specified navigates the top frame.
        /// </summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Referrer-policy used for the navigation.
        /// </summary>
        [JsonPropertyName("referrerPolicy")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ReferrerPolicy? ReferrerPolicy
        {
            get;
            set;
        }
    }

    public sealed class NavigateCommandResponse : ICommandResponse<NavigateCommand>
    {
        /// <summary>
        /// Frame id that has navigated (or failed to navigate)
        ///</summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Loader identifier. This is omitted in case of same-document navigation,
        /// as the previously committed loaderId would not change.
        ///</summary>
        [JsonPropertyName("loaderId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string LoaderId
        {
            get;
            set;
        }
        /// <summary>
        /// User friendly error message, present if and only if navigation has failed.
        ///</summary>
        [JsonPropertyName("errorText")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ErrorText
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the navigation resulted in a download.
        ///</summary>
        [JsonPropertyName("isDownload")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsDownload
        {
            get;
            set;
        }
    }
}