namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns information about the COEP/COOP isolation status.
    /// </summary>
    public sealed class GetSecurityIsolationStatusCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.getSecurityIsolationStatus";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// If no frameId is provided, the status of the target is provided.
        /// </summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FrameId
        {
            get;
            set;
        }
    }

    public sealed class GetSecurityIsolationStatusCommandResponse : ICommandResponse<GetSecurityIsolationStatusCommand>
    {
        /// <summary>
        /// Gets or sets the status
        /// </summary>
        [JsonPropertyName("status")]
        public SecurityIsolationStatus Status
        {
            get;
            set;
        }
    }
}