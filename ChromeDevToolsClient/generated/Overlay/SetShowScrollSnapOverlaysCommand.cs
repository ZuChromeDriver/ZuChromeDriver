namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SetShowScrollSnapOverlaysCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setShowScrollSnapOverlays";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// An array of node identifiers and descriptors for the highlight appearance.
        /// </summary>
        [JsonPropertyName("scrollSnapHighlightConfigs")]
        public ScrollSnapHighlightConfig[] ScrollSnapHighlightConfigs
        {
            get;
            set;
        }
    }

    public sealed class SetShowScrollSnapOverlaysCommandResponse : ICommandResponse<SetShowScrollSnapOverlaysCommand>
    {
    }
}