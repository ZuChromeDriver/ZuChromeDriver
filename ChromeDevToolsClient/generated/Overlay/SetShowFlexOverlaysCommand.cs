namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SetShowFlexOverlaysCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setShowFlexOverlays";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// An array of node identifiers and descriptors for the highlight appearance.
        /// </summary>
        [JsonPropertyName("flexNodeHighlightConfigs")]
        public FlexNodeHighlightConfig[] FlexNodeHighlightConfigs
        {
            get;
            set;
        }
    }

    public sealed class SetShowFlexOverlaysCommandResponse : ICommandResponse<SetShowFlexOverlaysCommand>
    {
    }
}