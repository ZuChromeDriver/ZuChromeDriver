namespace Zu.ChromeDevTools.Schema
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns supported domains.
    /// </summary>
    public sealed class GetDomainsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Schema.getDomains";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetDomainsCommandResponse : ICommandResponse<GetDomainsCommand>
    {
        /// <summary>
        /// List of supported domains.
        ///</summary>
        [JsonPropertyName("domains")]
        public Domain[] Domains
        {
            get;
            set;
        }
    }
}