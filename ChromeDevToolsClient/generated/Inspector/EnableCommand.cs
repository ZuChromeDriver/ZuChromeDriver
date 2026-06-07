namespace Zu.ChromeDevTools.Inspector
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enables inspector domain notifications.
    /// </summary>
    public sealed class EnableCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Inspector.enable";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class EnableCommandResponse : ICommandResponse<EnableCommand>
    {
    }
}