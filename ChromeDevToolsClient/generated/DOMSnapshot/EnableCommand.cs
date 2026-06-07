namespace Zu.ChromeDevTools.DOMSnapshot
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enables DOM snapshot agent for the given page.
    /// </summary>
    public sealed class EnableCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOMSnapshot.enable";
        
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