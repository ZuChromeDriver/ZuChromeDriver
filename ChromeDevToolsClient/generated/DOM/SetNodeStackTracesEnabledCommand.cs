namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets if stack traces should be captured for Nodes. See `Node.getNodeStackTraces`. Default is disabled.
    /// </summary>
    public sealed class SetNodeStackTracesEnabledCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.setNodeStackTracesEnabled";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Enable or disable.
        /// </summary>
        [JsonPropertyName("enable")]
        public bool Enable
        {
            get;
            set;
        }
    }

    public sealed class SetNodeStackTracesEnabledCommandResponse : ICommandResponse<SetNodeStackTracesEnabledCommand>
    {
    }
}