namespace Zu.ChromeDevTools.Log
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enables log domain, sends the entries collected so far to the client by means of the
    /// `entryAdded` notification.
    /// </summary>
    public sealed class EnableCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Log.enable";
        
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