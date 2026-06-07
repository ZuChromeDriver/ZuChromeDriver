namespace Zu.ChromeDevTools.IndexedDB
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enables events from backend.
    /// </summary>
    public sealed class EnableCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "IndexedDB.enable";
        
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