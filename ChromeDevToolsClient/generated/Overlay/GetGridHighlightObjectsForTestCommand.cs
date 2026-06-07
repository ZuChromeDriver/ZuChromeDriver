namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// For Persistent Grid testing.
    /// </summary>
    public sealed class GetGridHighlightObjectsForTestCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.getGridHighlightObjectsForTest";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Ids of the node to get highlight object for.
        /// </summary>
        [JsonPropertyName("nodeIds")]
        public long[] NodeIds
        {
            get;
            set;
        }
    }

    public sealed class GetGridHighlightObjectsForTestCommandResponse : ICommandResponse<GetGridHighlightObjectsForTestCommand>
    {
        /// <summary>
        /// Grid Highlight data for the node ids provided.
        ///</summary>
        [JsonPropertyName("highlights")]
        public object Highlights
        {
            get;
            set;
        }
    }
}