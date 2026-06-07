namespace Zu.ChromeDevTools.DOMSnapshot
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Document snapshot.
    /// </summary>
    public sealed class DocumentSnapshot
    {
        /// <summary>
        /// Document URL that `Document` or `FrameOwner` node points to.
        ///</summary>
        [JsonPropertyName("documentURL")]
        public long DocumentURL
        {
            get;
            set;
        }
        /// <summary>
        /// Document title.
        ///</summary>
        [JsonPropertyName("title")]
        public long Title
        {
            get;
            set;
        }
        /// <summary>
        /// Base URL that `Document` or `FrameOwner` node uses for URL completion.
        ///</summary>
        [JsonPropertyName("baseURL")]
        public long BaseURL
        {
            get;
            set;
        }
        /// <summary>
        /// Contains the document's content language.
        ///</summary>
        [JsonPropertyName("contentLanguage")]
        public long ContentLanguage
        {
            get;
            set;
        }
        /// <summary>
        /// Contains the document's character set encoding.
        ///</summary>
        [JsonPropertyName("encodingName")]
        public long EncodingName
        {
            get;
            set;
        }
        /// <summary>
        /// `DocumentType` node's publicId.
        ///</summary>
        [JsonPropertyName("publicId")]
        public long PublicId
        {
            get;
            set;
        }
        /// <summary>
        /// `DocumentType` node's systemId.
        ///</summary>
        [JsonPropertyName("systemId")]
        public long SystemId
        {
            get;
            set;
        }
        /// <summary>
        /// Frame ID for frame owner elements and also for the document node.
        ///</summary>
        [JsonPropertyName("frameId")]
        public long FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// A table with dom nodes.
        ///</summary>
        [JsonPropertyName("nodes")]
        public NodeTreeSnapshot Nodes
        {
            get;
            set;
        }
        /// <summary>
        /// The nodes in the layout tree.
        ///</summary>
        [JsonPropertyName("layout")]
        public LayoutTreeSnapshot Layout
        {
            get;
            set;
        }
        /// <summary>
        /// The post-layout inline text nodes.
        ///</summary>
        [JsonPropertyName("textBoxes")]
        public TextBoxSnapshot TextBoxes
        {
            get;
            set;
        }
        /// <summary>
        /// Horizontal scroll offset.
        ///</summary>
        [JsonPropertyName("scrollOffsetX")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? ScrollOffsetX
        {
            get;
            set;
        }
        /// <summary>
        /// Vertical scroll offset.
        ///</summary>
        [JsonPropertyName("scrollOffsetY")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? ScrollOffsetY
        {
            get;
            set;
        }
        /// <summary>
        /// Document content width.
        ///</summary>
        [JsonPropertyName("contentWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? ContentWidth
        {
            get;
            set;
        }
        /// <summary>
        /// Document content height.
        ///</summary>
        [JsonPropertyName("contentHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? ContentHeight
        {
            get;
            set;
        }
    }
}