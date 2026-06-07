namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Reports an error result for the given request.
    /// </summary>
    public sealed class ReportErrorCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "SmartCardEmulation.reportError";
        
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
        /// Gets or sets the resultCode
        /// </summary>
        [JsonPropertyName("resultCode")]
        public ResultCode ResultCode
        {
            get;
            set;
        }
    }

    public sealed class ReportErrorCommandResponse : ICommandResponse<ReportErrorCommand>
    {
    }
}