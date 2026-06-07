namespace Zu.ChromeDevTools.Security
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enable/disable overriding certificate errors. If enabled, all certificate error events need to
    /// be handled by the DevTools client and should be answered with `handleCertificateError` commands.
    /// </summary>
    public sealed class SetOverrideCertificateErrorsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Security.setOverrideCertificateErrors";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// If true, certificate errors will be overridden.
        /// </summary>
        [JsonPropertyName("override")]
        public bool Override
        {
            get;
            set;
        }
    }

    public sealed class SetOverrideCertificateErrorsCommandResponse : ICommandResponse<SetOverrideCertificateErrorsCommand>
    {
    }
}