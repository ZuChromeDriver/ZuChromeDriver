namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns present frame / resource tree structure.
    /// </summary>
    public sealed class GetResourceTreeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.getResourceTree";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetResourceTreeCommandResponse : ICommandResponse<GetResourceTreeCommand>
    {
        /// <summary>
        /// Present frame / resource tree structure.
        ///</summary>
        [JsonPropertyName("frameTree")]
        public FrameResourceTree FrameTree
        {
            get;
            set;
        }
    }
}