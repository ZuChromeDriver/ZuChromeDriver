namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets given cookies.
    /// </summary>
    public sealed class SetCookiesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.setCookies";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Cookies to be set.
        /// </summary>
        [JsonPropertyName("cookies")]
        public CookieParam[] Cookies
        {
            get;
            set;
        }
    }

    public sealed class SetCookiesCommandResponse : ICommandResponse<SetCookiesCommand>
    {
    }
}