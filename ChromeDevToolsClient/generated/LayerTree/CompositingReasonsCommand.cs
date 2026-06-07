namespace Zu.ChromeDevTools.LayerTree
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Provides the reasons why the given layer was composited.
    /// </summary>
    public sealed class CompositingReasonsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "LayerTree.compositingReasons";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// The id of the layer for which we want to get the reasons it was composited.
        /// </summary>
        [JsonPropertyName("layerId")]
        public string LayerId
        {
            get;
            set;
        }
    }

    public sealed class CompositingReasonsCommandResponse : ICommandResponse<CompositingReasonsCommand>
    {
        /// <summary>
        /// A list of strings specifying reasons for the given layer to become composited.
        ///</summary>
        [JsonPropertyName("compositingReasons")]
        public string[] CompositingReasons
        {
            get;
            set;
        }
        /// <summary>
        /// A list of strings specifying reason IDs for the given layer to become composited.
        ///</summary>
        [JsonPropertyName("compositingReasonIds")]
        public string[] CompositingReasonIds
        {
            get;
            set;
        }
    }
}