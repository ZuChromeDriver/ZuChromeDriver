namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Reports the successful result of a |SCardConnect| call.
    /// 
    /// This maps to:
    /// PC/SC Lite: https://pcsclite.apdu.fr/api/group__API.html#ga4e515829752e0a8dbc4d630696a8d6a5
    /// Microsoft: https://learn.microsoft.com/en-us/windows/win32/api/winscard/nf-winscard-scardconnecta
    /// </summary>
    public sealed class ReportConnectResultCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "SmartCardEmulation.reportConnectResult";
        
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
        /// Gets or sets the handle
        /// </summary>
        [JsonPropertyName("handle")]
        public long Handle
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the activeProtocol
        /// </summary>
        [JsonPropertyName("activeProtocol")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Protocol? ActiveProtocol
        {
            get;
            set;
        }
    }

    public sealed class ReportConnectResultCommandResponse : ICommandResponse<ReportConnectResultCommand>
    {
    }
}