namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns content of the given resource.
    /// </summary>
    public sealed class GetResourceContentCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.getResourceContent";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Frame id to get resource for.
        /// </summary>
        [JsonPropertyName("frameId")]
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
    }

    public sealed class GetResourceContentCommandResponse : ICommandResponse<GetResourceContentCommand>
    {
        /// <summary>
        /// Resource content.
        ///</summary>
        [JsonPropertyName("content")]
        public string Content
        {
            get;
            set;
        }
        /// <summary>
        /// True, if content was served as base64.
        ///</summary>
        [JsonPropertyName("base64Encoded")]
        public bool Base64Encoded
        {
            get;
            set;
        }
    }
}