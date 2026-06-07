namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the DER-encoded certificate.
    /// </summary>
    public sealed class GetCertificateCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.getCertificate";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Origin to get certificate for.
        /// </summary>
        [JsonPropertyName("origin")]
        public string Origin
        {
            get;
            set;
        }
    }

    public sealed class GetCertificateCommandResponse : ICommandResponse<GetCertificateCommand>
    {
        /// <summary>
        /// Gets or sets the tableNames
        /// </summary>
        [JsonPropertyName("tableNames")]
        public string[] TableNames
        {
            get;
            set;
        }
    }
}