namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Requests that a batch of nodes is sent to the caller given their backend node ids.
    /// </summary>
    public sealed class PushNodesByBackendIdsToFrontendCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.pushNodesByBackendIdsToFrontend";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The array of backend node ids.
        /// </summary>
        [JsonPropertyName("backendNodeIds")]
        public long[] BackendNodeIds
        {
            get;
            set;
        }
    }

    public sealed class PushNodesByBackendIdsToFrontendCommandResponse : ICommandResponse<PushNodesByBackendIdsToFrontendCommand>
    {
        /// <summary>
        /// The array of ids of pushed nodes that correspond to the backend ids specified in
        /// backendNodeIds.
        ///</summary>
        [JsonPropertyName("nodeIds")]
        public long[] NodeIds
        {
            get;
            set;
        }
    }
}