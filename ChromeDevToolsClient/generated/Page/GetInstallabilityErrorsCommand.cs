namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class GetInstallabilityErrorsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.getInstallabilityErrors";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetInstallabilityErrorsCommandResponse : ICommandResponse<GetInstallabilityErrorsCommand>
    {
        /// <summary>
        /// Gets or sets the installabilityErrors
        /// </summary>
        [JsonPropertyName("installabilityErrors")]
        public InstallabilityError[] InstallabilityErrors
        {
            get;
            set;
        }
    }
}