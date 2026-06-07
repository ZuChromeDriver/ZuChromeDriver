namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SetShowInspectedElementAnchorCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setShowInspectedElementAnchor";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Node identifier for which to show an anchor for.
        /// </summary>
        [JsonPropertyName("inspectedElementAnchorConfig")]
        public InspectedElementAnchorConfig InspectedElementAnchorConfig
        {
            get;
            set;
        }
    }

    public sealed class SetShowInspectedElementAnchorCommandResponse : ICommandResponse<SetShowInspectedElementAnchorCommand>
    {
    }
}