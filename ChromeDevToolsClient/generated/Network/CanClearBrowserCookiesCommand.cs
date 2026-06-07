namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Tells whether clearing browser cookies is supported.
    /// </summary>
    public sealed class CanClearBrowserCookiesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.canClearBrowserCookies";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class CanClearBrowserCookiesCommandResponse : ICommandResponse<CanClearBrowserCookiesCommand>
    {
        /// <summary>
        /// True if browser cookies can be cleared.
        ///</summary>
        [JsonPropertyName("result")]
        public bool Result
        {
            get;
            set;
        }
    }
}