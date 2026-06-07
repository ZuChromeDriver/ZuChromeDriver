namespace Zu.ChromeDevTools.DOMStorage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Disables storage tracking, prevents storage events from being sent to the client.
    /// </summary>
    public sealed class DisableCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMStorage.disable";
        
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