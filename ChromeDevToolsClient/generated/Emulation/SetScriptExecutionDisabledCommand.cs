namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Switches script execution in the page.
    /// </summary>
    public sealed class SetScriptExecutionDisabledCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setScriptExecutionDisabled";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Whether script execution should be disabled in the page.
        /// </summary>
        [JsonPropertyName("value")]
        public bool Value
        {
            get;
            set;
        }
    }

    public sealed class SetScriptExecutionDisabledCommandResponse : ICommandResponse<SetScriptExecutionDisabledCommand>
    {
    }
}