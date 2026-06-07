namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fetches the resource and returns the content.
    /// </summary>
    public sealed class LoadNetworkResourceCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.loadNetworkResource";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Frame id to get the resource for. Mandatory for frame targets, and
        /// should be omitted for worker targets.
        /// </summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// URL of the resource to get content for.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Options for the request.
        /// </summary>
        [JsonPropertyName("options")]
        public LoadNetworkResourceOptions Options
        {
            get;
            set;
        }
    }

    public sealed class LoadNetworkResourceCommandResponse : ICommandResponse<LoadNetworkResourceCommand>
    {
        /// <summary>
        /// Gets or sets the resource
        /// </summary>
        [JsonPropertyName("resource")]
        public LoadNetworkResourcePageResult Resource
        {
            get;
            set;
        }
    }
}