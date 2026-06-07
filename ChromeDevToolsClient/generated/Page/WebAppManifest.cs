namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class WebAppManifest
    {
        /// <summary>
        /// Gets or sets the backgroundColor
        /// </summary>
        [JsonPropertyName("backgroundColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BackgroundColor
        {
            get;
            set;
        }
        /// <summary>
        /// The extra description provided by the manifest.
        ///</summary>
        [JsonPropertyName("description")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the dir
        /// </summary>
        [JsonPropertyName("dir")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Dir
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the display
        /// </summary>
        [JsonPropertyName("display")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Display
        {
            get;
            set;
        }
        /// <summary>
        /// The overrided display mode controlled by the user.
        ///</summary>
        [JsonPropertyName("displayOverrides")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string[] DisplayOverrides
        {
            get;
            set;
        }
        /// <summary>
        /// The handlers to open files.
        ///</summary>
        [JsonPropertyName("fileHandlers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FileHandler[] FileHandlers
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
        /// Gets or sets the id
        /// </summary>
        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the lang
        /// </summary>
        [JsonPropertyName("lang")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Lang
        {
            get;
            set;
        }
        /// <summary>
        /// TODO(crbug.com/1231886): This field is non-standard and part of a Chrome
        /// experiment. See:
        /// https://github.com/WICG/web-app-launch/blob/main/launch_handler.md
        ///</summary>
        [JsonPropertyName("launchHandler")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public LaunchHandler LaunchHandler
        {
            get;
            set;
        }
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
        /// Gets or sets the orientation
        /// </summary>
        [JsonPropertyName("orientation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Orientation
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the preferRelatedApplications
        /// </summary>
        [JsonPropertyName("preferRelatedApplications")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? PreferRelatedApplications
        {
            get;
            set;
        }
        /// <summary>
        /// The handlers to open protocols.
        ///</summary>
        [JsonPropertyName("protocolHandlers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ProtocolHandler[] ProtocolHandlers
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the relatedApplications
        /// </summary>
        [JsonPropertyName("relatedApplications")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RelatedApplication[] RelatedApplications
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the scope
        /// </summary>
        [JsonPropertyName("scope")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Scope
        {
            get;
            set;
        }
        /// <summary>
        /// Non-standard, see
        /// https://github.com/WICG/manifest-incubations/blob/gh-pages/scope_extensions-explainer.md
        ///</summary>
        [JsonPropertyName("scopeExtensions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ScopeExtension[] ScopeExtensions
        {
            get;
            set;
        }
        /// <summary>
        /// The screenshots used by chromium.
        ///</summary>
        [JsonPropertyName("screenshots")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Screenshot[] Screenshots
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the shareTarget
        /// </summary>
        [JsonPropertyName("shareTarget")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ShareTarget ShareTarget
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the shortName
        /// </summary>
        [JsonPropertyName("shortName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ShortName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the shortcuts
        /// </summary>
        [JsonPropertyName("shortcuts")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Shortcut[] Shortcuts
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the startUrl
        /// </summary>
        [JsonPropertyName("startUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string StartUrl
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the themeColor
        /// </summary>
        [JsonPropertyName("themeColor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ThemeColor
        {
            get;
            set;
        }
    }
}