namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Reports the successful result of a |SCardReleaseContext| call.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga6aabcba7744c5c9419fdd6404f73a934
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardreleasecontext
    /// </summary>
    public sealed class ReportReleaseContextResultCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "SmartCardEmulation.reportReleaseContextResult";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the requestId
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
    }

    public sealed class ReportReleaseContextResultCommandResponse : ICommandResponse<ReportReleaseContextResultCommand>
    {
    }
}