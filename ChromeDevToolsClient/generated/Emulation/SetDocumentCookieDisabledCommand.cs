namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SetDocumentCookieDisabledCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setDocumentCookieDisabled";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Whether document.coookie API should be disabled.
        /// </summary>
        [JsonPropertyName("disabled")]
        public bool Disabled
        {
            get;
            set;
        }
    }

    public sealed class SetDocumentCookieDisabledCommandResponse : ICommandResponse<SetDocumentCookieDisabledCommand>
    {
    }
}