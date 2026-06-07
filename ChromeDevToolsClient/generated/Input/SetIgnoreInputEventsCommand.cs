namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Ignores input events (useful while auditing page).
    /// </summary>
    public sealed class SetIgnoreInputEventsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Input.setIgnoreInputEvents";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Ignores input events processing when set to true.
        /// </summary>
        [JsonPropertyName("ignore")]
        public bool Ignore
        {
            get;
            set;
        }
    }

    public sealed class SetIgnoreInputEventsCommandResponse : ICommandResponse<SetIgnoreInputEventsCommand>
    {
    }
}