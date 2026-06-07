namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets given cookies.
    /// </summary>
    public sealed class SetCookiesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.setCookies";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Cookies to be set.
        /// </summary>
        [JsonPropertyName("cookies")]
        public Network.CookieParam[] Cookies
        {
            get;
            set;
        }
        /// <summary>
        /// Browser context to use when called on the browser endpoint.
        /// </summary>
        [JsonPropertyName("browserContextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BrowserContextId
        {
            get;
            set;
        }
    }

    public sealed class SetCookiesCommandResponse : ICommandResponse<SetCookiesCommand>
    {
    }
}