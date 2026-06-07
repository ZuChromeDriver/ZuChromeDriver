namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Opens a DevTools window for the target.
    /// </summary>
    public sealed class OpenDevToolsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Target.openDevTools";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// This can be the page or tab target ID.
        /// </summary>
        [JsonPropertyName("targetId")]
        public string TargetId
        {
            get;
            set;
        }
        /// <summary>
        /// The id of the panel we want DevTools to open initially. Currently
        /// supported panels are elements, console, network, sources, resources
        /// and performance.
        /// </summary>
        [JsonPropertyName("panelId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PanelId
        {
            get;
            set;
        }
    }

    public sealed class OpenDevToolsCommandResponse : ICommandResponse<OpenDevToolsCommand>
    {
        /// <summary>
        /// The targetId of DevTools page target.
        ///</summary>
        [JsonPropertyName("targetId")]
        public string TargetId
        {
            get;
            set;
        }
    }
}