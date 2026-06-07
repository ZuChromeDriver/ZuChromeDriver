namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Reset all permission management for all origins.
    /// </summary>
    public sealed class ResetPermissionsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Browser.resetPermissions";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// BrowserContext to reset permissions. When omitted, default browser context is used.
        /// </summary>
        [JsonPropertyName("browserContextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BrowserContextId
        {
            get;
            set;
        }
    }

    public sealed class ResetPermissionsCommandResponse : ICommandResponse<ResetPermissionsCommand>
    {
    }
}