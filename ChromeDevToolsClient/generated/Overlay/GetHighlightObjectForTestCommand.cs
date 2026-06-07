namespace Zu.ChromeDevTools.Overlay
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// For testing.
    /// </summary>
    public sealed class GetHighlightObjectForTestCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Overlay.getHighlightObjectForTest";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Id of the node to get highlight object for.
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to include distance info.
        /// </summary>
        [JsonPropertyName("includeDistance")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludeDistance
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to include style info.
        /// </summary>
        [JsonPropertyName("includeStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IncludeStyle
        {
            get;
            set;
        }
        /// <summary>
        /// The color format to get config with (default: hex).
        /// </summary>
        [JsonPropertyName("colorFormat")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ColorFormat? ColorFormat
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to show accessibility info (default: true).
        /// </summary>
        [JsonPropertyName("showAccessibilityInfo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? ShowAccessibilityInfo
        {
            get;
            set;
        }
    }

    public sealed class GetHighlightObjectForTestCommandResponse : ICommandResponse<GetHighlightObjectForTestCommand>
    {
        /// <summary>
        /// Highlight data for the node.
        ///</summary>
        [JsonPropertyName("highlight")]
        public object Highlight
        {
            get;
            set;
        }
    }
}