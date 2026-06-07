namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Cancel a download if in progress
    /// </summary>
    public sealed class CancelDownloadCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Browser.cancelDownload";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Global unique identifier of the download.
        /// </summary>
        [JsonPropertyName("guid")]
        public string Guid
        {
            get;
            set;
        }
        /// <summary>
        /// BrowserContext to perform the action in. When omitted, default browser context is used.
        /// </summary>
        [JsonPropertyName("browserContextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BrowserContextId
        {
            get;
            set;
        }
    }

    public sealed class CancelDownloadCommandResponse : ICommandResponse<CancelDownloadCommand>
    {
    }
}