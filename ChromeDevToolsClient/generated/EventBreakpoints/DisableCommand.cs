namespace Zu.ChromeDevTools.EventBreakpoints
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Removes all breakpoints
    /// </summary>
    public sealed class DisableCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "EventBreakpoints.disable";
        
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