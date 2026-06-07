namespace Zu.ChromeDevTools.DeviceAccess
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Disable events in this domain.
    /// </summary>
    public sealed class DisableCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DeviceAccess.disable";
        
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