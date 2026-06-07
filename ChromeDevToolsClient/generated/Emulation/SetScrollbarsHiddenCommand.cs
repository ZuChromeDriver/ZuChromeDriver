namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SetScrollbarsHiddenCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setScrollbarsHidden";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Whether scrollbars should be always hidden.
        /// </summary>
        [JsonPropertyName("hidden")]
        public bool Hidden
        {
            get;
            set;
        }
    }

    public sealed class SetScrollbarsHiddenCommandResponse : ICommandResponse<SetScrollbarsHiddenCommand>
    {
    }
}