namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns all browser cookies.
    /// </summary>
    public sealed class GetCookiesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.getCookies";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
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

    public sealed class GetCookiesCommandResponse : ICommandResponse<GetCookiesCommand>
    {
        /// <summary>
        /// Array of cookie objects.
        ///</summary>
        [JsonPropertyName("cookies")]
        public Network.Cookie[] Cookies
        {
            get;
            set;
        }
    }
}