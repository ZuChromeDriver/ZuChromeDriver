namespace Zu.ChromeDevTools.Console
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Does nothing.
    /// </summary>
    public sealed class ClearMessagesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Console.clearMessages";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class ClearMessagesCommandResponse : ICommandResponse<ClearMessagesCommand>
    {
    }
}