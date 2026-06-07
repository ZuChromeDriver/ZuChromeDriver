namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Deletes browser cookies with matching name and url or domain/path/partitionKey pair.
    /// </summary>
    public sealed class DeleteCookiesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.deleteCookies";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Name of the cookies to remove.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// If specified, deletes all the cookies with the given name where domain and path match
        /// provided URL.
        /// </summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// If specified, deletes only cookies with the exact domain.
        /// </summary>
        [JsonPropertyName("domain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Domain
        {
            get;
            set;
        }
        /// <summary>
        /// If specified, deletes only cookies with the exact path.
        /// </summary>
        [JsonPropertyName("path")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Path
        {
            get;
            set;
        }
        /// <summary>
        /// If specified, deletes only cookies with the the given name and partitionKey where
        /// all partition key attributes match the cookie partition key attribute.
        /// </summary>
        [JsonPropertyName("partitionKey")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CookiePartitionKey PartitionKey
        {
            get;
            set;
        }
    }

    public sealed class DeleteCookiesCommandResponse : ICommandResponse<DeleteCookiesCommand>
    {
    }
}