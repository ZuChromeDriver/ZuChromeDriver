namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enters the 'inspect' mode. In this mode, elements that user is hovering over are highlighted.
    /// Backend then generates 'inspectNodeRequested' event upon element selection.
    /// </summary>
    public sealed class SetInspectModeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.setInspectMode";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Set an inspection mode.
        /// </summary>
        [JsonPropertyName("mode")]
        public InspectMode Mode
        {
            get;
            set;
        }
        /// <summary>
        /// A descriptor for the highlight appearance of hovered-over nodes. May be omitted if `enabled
        /// == false`.
        /// </summary>
        [JsonPropertyName("highlightConfig")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public HighlightConfig HighlightConfig
        {
            get;
            set;
        }
    }

    public sealed class SetInspectModeCommandResponse : ICommandResponse<SetInspectModeCommand>
    {
    }
}