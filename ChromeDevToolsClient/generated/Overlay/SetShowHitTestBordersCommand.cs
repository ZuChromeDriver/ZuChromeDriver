namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Deprecated, no longer has any effect.
    /// </summary>
    public sealed class SetShowHitTestBordersCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setShowHitTestBorders";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// True for showing hit-test borders
        /// </summary>
        [JsonPropertyName("show")]
        public bool Show
        {
            get;
            set;
        }
    }

    public sealed class SetShowHitTestBordersCommandResponse : ICommandResponse<SetShowHitTestBordersCommand>
    {
    }
}