namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fetches the schemeful site for a specific origin.
    /// </summary>
    public sealed class FetchSchemefulSiteCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.fetchSchemefulSite";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The URL origin.
        /// </summary>
        [JsonPropertyName("origin")]
        public string Origin
        {
            get;
            set;
        }
    }

    public sealed class FetchSchemefulSiteCommandResponse : ICommandResponse<FetchSchemefulSiteCommand>
    {
        /// <summary>
        /// The corresponding schemeful site.
        ///</summary>
        [JsonPropertyName("schemefulSite")]
        public string SchemefulSite
        {
            get;
            set;
        }
    }
}