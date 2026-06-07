namespace Zu.ChromeDevTools.BackgroundService
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Set the recording state for the service.
    /// </summary>
    public sealed class SetRecordingCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "BackgroundService.setRecording";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the shouldRecord
        /// </summary>
        [JsonPropertyName("shouldRecord")]
        public bool ShouldRecord
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the service
        /// </summary>
        [JsonPropertyName("service")]
        public ServiceName Service
        {
            get;
            set;
        }
    }

    public sealed class SetRecordingCommandResponse : ICommandResponse<SetRecordingCommand>
    {
    }
}