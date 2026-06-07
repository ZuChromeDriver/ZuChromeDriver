namespace Zu.ChromeDevTools.Log
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clears the log.
    /// </summary>
    public sealed class ClearCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Log.clear";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class ClearCommandResponse : ICommandResponse<ClearCommand>
    {
    }
}