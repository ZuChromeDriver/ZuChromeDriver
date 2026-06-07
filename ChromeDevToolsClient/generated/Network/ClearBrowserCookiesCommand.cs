namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clears browser cookies.
    /// </summary>
    public sealed class ClearBrowserCookiesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.clearBrowserCookies";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class ClearBrowserCookiesCommandResponse : ICommandResponse<ClearBrowserCookiesCommand>
    {
    }
}