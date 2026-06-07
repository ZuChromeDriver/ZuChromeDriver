namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns all browser cookies. Depending on the backend support, will return detailed cookie
    /// information in the `cookies` field.
    /// Deprecated. Use Storage.getCookies instead.
    /// </summary>
    public sealed class GetAllCookiesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.getAllCookies";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetAllCookiesCommandResponse : ICommandResponse<GetAllCookiesCommand>
    {
        /// <summary>
        /// Array of cookie objects.
        ///</summary>
        [JsonPropertyName("cookies")]
        public Cookie[] Cookies
        {
            get;
            set;
        }
    }
}