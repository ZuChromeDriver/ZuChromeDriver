namespace Zu.ChromeDevTools.BackgroundService
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enables event updates for the service.
    /// </summary>
    public sealed class StartObservingCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "BackgroundService.startObserving";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
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

    public sealed class StartObservingCommandResponse : ICommandResponse<StartObservingCommand>
    {
    }
}