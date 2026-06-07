namespace Zu.ChromeDevTools.DOM
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns file information for the given
    /// File wrapper.
    /// </summary>
    public sealed class GetFileInfoCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "DOM.getFileInfo";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// JavaScript object id of the node wrapper.
        /// </summary>
        [JsonPropertyName("objectId")]
        public string ObjectId
        {
            get;
            set;
        }
    }

    public sealed class GetFileInfoCommandResponse : ICommandResponse<GetFileInfoCommand>
    {
        /// <summary>
        /// Gets or sets the path
        /// </summary>
        [JsonPropertyName("path")]
        public string Path
        {
            get;
            set;
        }
    }
}