namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Reports the successful result of a |SCardListReaders| call.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga93b07815789b3cf2629d439ecf20f0d9
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardlistreadersa
    /// </summary>
    public sealed class ReportListReadersResultCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "SmartCardEmulation.reportListReadersResult";
        
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
        /// <summary>
        /// Gets or sets the readers
        /// </summary>
        [JsonPropertyName("readers")]
        public string[] Readers
        {
            get;
            set;
        }
    }

    public sealed class ReportListReadersResultCommandResponse : ICommandResponse<ReportListReadersResultCommand>
    {
    }
}