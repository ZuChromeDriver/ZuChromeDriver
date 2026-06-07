namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Get the browser window that contains the devtools target.
    /// </summary>
    public sealed class GetWindowForTargetCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Browser.getWindowForTarget";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Devtools agent host id. If called as a part of the session, associated targetId is used.
        /// </summary>
        [JsonPropertyName("targetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TargetId
        {
            get;
            set;
        }
    }

    public sealed class GetWindowForTargetCommandResponse : ICommandResponse<GetWindowForTargetCommand>
    {
        /// <summary>
        /// Browser window id.
        ///</summary>
        [JsonPropertyName("windowId")]
        public long WindowId
        {
            get;
            set;
        }
        /// <summary>
        /// Bounds information of the window. When window state is 'minimized', the restored window
        /// position and size are returned.
        ///</summary>
        [JsonPropertyName("bounds")]
        public Bounds Bounds
        {
            get;
            set;
        }
    }
}