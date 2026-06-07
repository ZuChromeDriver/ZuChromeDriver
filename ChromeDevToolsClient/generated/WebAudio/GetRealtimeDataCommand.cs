namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fetch the realtime data from the registered contexts.
    /// </summary>
    public sealed class GetRealtimeDataCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "WebAudio.getRealtimeData";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the contextId
        /// </summary>
        [JsonPropertyName("contextId")]
        public string ContextId
        {
            get;
            set;
        }
    }

    public sealed class GetRealtimeDataCommandResponse : ICommandResponse<GetRealtimeDataCommand>
    {
        /// <summary>
        /// Gets or sets the realtimeData
        /// </summary>
        [JsonPropertyName("realtimeData")]
        public ContextRealtimeData RealtimeData
        {
            get;
            set;
        }
    }
}