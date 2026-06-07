namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Creates a new page.
    /// </summary>
    public sealed class CreateTargetCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Target.createTarget";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The initial URL the page will be navigated to. An empty string indicates about:blank.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Frame left origin in DIP (requires newWindow to be true or headless shell).
        /// </summary>
        [JsonPropertyName("left")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Left
        {
            get;
            set;
        }
        /// <summary>
        /// Frame top origin in DIP (requires newWindow to be true or headless shell).
        /// </summary>
        [JsonPropertyName("top")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Top
        {
            get;
            set;
        }
        /// <summary>
        /// Frame width in DIP (requires newWindow to be true or headless shell).
        /// </summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Width
        {
            get;
            set;
        }
        /// <summary>
        /// Frame height in DIP (requires newWindow to be true or headless shell).
        /// </summary>
        [JsonPropertyName("height")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Height
        {
            get;
            set;
        }
        /// <summary>
        /// Frame window state (requires newWindow to be true or headless shell).
        /// Default is normal.
        /// </summary>
        [JsonPropertyName("windowState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public WindowState? WindowState
        {
            get;
            set;
        }
        /// <summary>
        /// The browser context to create the page in.
        /// </summary>
        [JsonPropertyName("browserContextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BrowserContextId
        {
            get;
            set;
        }
        /// <summary>
        /// Whether BeginFrames for this target will be controlled via DevTools (headless shell only,
        /// not supported on MacOS yet, false by default).
        /// </summary>
        [JsonPropertyName("enableBeginFrameControl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? EnableBeginFrameControl
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to create a new Window or Tab (false by default, not supported by headless shell).
        /// </summary>
        [JsonPropertyName("newWindow")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? NewWindow
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to create the target in background or foreground (false by default, not supported
        /// by headless shell).
        /// </summary>
        [JsonPropertyName("background")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Background
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to create the target of type "tab".
        /// </summary>
        [JsonPropertyName("forTab")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ForTab
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to create a hidden target. The hidden target is observable via protocol, but not
        /// present in the tab UI strip. Cannot be created with `forTab: true`, `newWindow: true` or
        /// `background: false`. The life-time of the tab is limited to the life-time of the session.
        /// </summary>
        [JsonPropertyName("hidden")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Hidden
        {
            get;
            set;
        }
        /// <summary>
        /// If specified, the option is used to determine if the new target should
        /// be focused or not. By default, the focus behavior depends on the
        /// value of the background field. For example, background=false and focus=false
        /// will result in the target tab being opened but the browser window remain
        /// unchanged (if it was in the background, it will remain in the background)
        /// and background=false with focus=undefined will result in the window being focused.
        /// Using background: true and focus: true is not supported and will result in an error.
        /// </summary>
        [JsonPropertyName("focus")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Focus
        {
            get;
            set;
        }
    }

    public sealed class CreateTargetCommandResponse : ICommandResponse<CreateTargetCommand>
    {
        /// <summary>
        /// The id of the page opened.
        ///</summary>
        [JsonPropertyName("targetId")]
        public string TargetId
        {
            get;
            set;
        }
    }
}