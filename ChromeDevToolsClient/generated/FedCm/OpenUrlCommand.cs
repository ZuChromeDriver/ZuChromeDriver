namespace Zu.ChromeDevTools.FedCm
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class OpenUrlCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "FedCm.openUrl";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the dialogId
        /// </summary>
        [JsonPropertyName("dialogId")]
        public string DialogId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the accountIndex
        /// </summary>
        [JsonPropertyName("accountIndex")]
        public long AccountIndex
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the accountUrlType
        /// </summary>
        [JsonPropertyName("accountUrlType")]
        public AccountUrlType AccountUrlType
        {
            get;
            set;
        }
    }

    public sealed class OpenUrlCommandResponse : ICommandResponse<OpenUrlCommand>
    {
    }
}