namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Get position and size of the browser window.
    /// </summary>
    public sealed class GetWindowBoundsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Browser.getWindowBounds";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Browser window id.
        /// </summary>
        [JsonPropertyName("windowId")]
        public long WindowId
        {
            get;
            set;
        }
    }

    public sealed class GetWindowBoundsCommandResponse : ICommandResponse<GetWindowBoundsCommand>
    {
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