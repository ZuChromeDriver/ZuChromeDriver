namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clears browser cache.
    /// </summary>
    public sealed class ClearBrowserCacheCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.clearBrowserCache";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class ClearBrowserCacheCommandResponse : ICommandResponse<ClearBrowserCacheCommand>
    {
    }
}