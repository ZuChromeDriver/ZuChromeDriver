namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Reports the successful result of a |SCardStatus| call.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#gae49c3c894ad7ac12a5b896bde70d0382
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardstatusa
    /// </summary>
    public sealed class ReportStatusResultCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "SmartCardEmulation.reportStatusResult";
        
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
        /// Gets or sets the readerName
        /// </summary>
        [JsonPropertyName("readerName")]
        public string ReaderName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the state
        /// </summary>
        [JsonPropertyName("state")]
        public ConnectionState State
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the atr
        /// </summary>
        [JsonPropertyName("atr")]
        public string Atr
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the protocol
        /// </summary>
        [JsonPropertyName("protocol")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Protocol? Protocol
        {
            get;
            set;
        }
    }

    public sealed class ReportStatusResultCommandResponse : ICommandResponse<ReportStatusResultCommand>
    {
    }
}