namespace Zu.ChromeDevTools.Autofill
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Disables autofill domain notifications.
    /// </summary>
    public sealed class DisableCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Autofill.disable";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class DisableCommandResponse : ICommandResponse<DisableCommand>
    {
    }
}