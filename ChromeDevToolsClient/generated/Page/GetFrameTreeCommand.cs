namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns present frame tree structure.
    /// </summary>
    public sealed class GetFrameTreeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.getFrameTree";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetFrameTreeCommandResponse : ICommandResponse<GetFrameTreeCommand>
    {
        /// <summary>
        /// Present frame tree structure.
        ///</summary>
        [JsonPropertyName("frameTree")]
        public FrameTree FrameTree
        {
            get;
            set;
        }
    }
}