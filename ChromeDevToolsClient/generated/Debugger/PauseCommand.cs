namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Stops on the next JavaScript statement.
    /// </summary>
    public sealed class PauseCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.pause";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class PauseCommandResponse : ICommandResponse<PauseCommand>
    {
    }
}