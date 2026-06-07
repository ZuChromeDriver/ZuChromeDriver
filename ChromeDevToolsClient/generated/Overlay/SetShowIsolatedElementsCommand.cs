namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Show elements in isolation mode with overlays.
    /// </summary>
    public sealed class SetShowIsolatedElementsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setShowIsolatedElements";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// An array of node identifiers and descriptors for the highlight appearance.
        /// </summary>
        [JsonPropertyName("isolatedElementHighlightConfigs")]
        public IsolatedElementHighlightConfig[] IsolatedElementHighlightConfigs
        {
            get;
            set;
        }
    }

    public sealed class SetShowIsolatedElementsCommandResponse : ICommandResponse<SetShowIsolatedElementsCommand>
    {
    }
}