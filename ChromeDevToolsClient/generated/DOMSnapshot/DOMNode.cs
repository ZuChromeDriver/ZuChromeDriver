namespace Zu.ChromeDevTools.DOMSnapshot
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A Node in the DOM tree.
    /// </summary>
    public sealed class DOMNode
    {
        /// <summary>
        /// `Node`'s nodeType.
        ///</summary>
        [JsonPropertyName("nodeType")]
        public long NodeType
        {
            get;
            set;
        }
        /// <summary>
        /// `Node`'s nodeName.
        ///</summary>
        [JsonPropertyName("nodeName")]
        public string NodeName
        {
            get;
            set;
        }
        /// <summary>
        /// `Node`'s nodeValue.
        ///</summary>
        [JsonPropertyName("nodeValue")]
        public string NodeValue
        {
            get;
            set;
        }
        /// <summary>
        /// Only set for textarea elements, contains the text value.
        ///</summary>
        [JsonPropertyName("textValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TextValue
        {
            get;
            set;
        }
        /// <summary>
        /// Only set for input elements, contains the input's associated text value.
        ///</summary>
        [JsonPropertyName("inputValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string InputValue
        {
            get;
            set;
        }
        /// <summary>
        /// Only set for radio and checkbox input elements, indicates if the element has been checked
        ///</summary>
        [JsonPropertyName("inputChecked")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? InputChecked
        {
            get;
            set;
        }
        /// <summary>
        /// Only set for option elements, indicates if the element has been selected
        ///</summary>
        [JsonPropertyName("optionSelected")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? OptionSelected
        {
            get;
            set;
        }
        /// <summary>
        /// `Node`'s id, corresponds to DOM.Node.backendNodeId.
        ///</summary>
        [JsonPropertyName("backendNodeId")]
        public long BackendNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// The indexes of the node's child nodes in the `domNodes` array returned by `getSnapshot`, if
        /// any.
        ///</summary>
        [JsonPropertyName("childNodeIndexes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[] ChildNodeIndexes
        {
            get;
            set;
        }
        /// <summary>
        /// Attributes of an `Element` node.
        ///</summary>
        [JsonPropertyName("attributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public NameValue[] Attributes
        {
            get;
            set;
        }
        /// <summary>
        /// Indexes of pseudo elements associated with this node in the `domNodes` array returned by
        /// `getSnapshot`, if any.
        ///</summary>
        [JsonPropertyName("pseudoElementIndexes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[] PseudoElementIndexes
        {
            get;
            set;
        }
        /// <summary>
        /// The index of the node's related layout tree node in the `layoutTreeNodes` array returned by
        /// `getSnapshot`, if any.
        ///</summary>
        [JsonPropertyName("layoutNodeIndex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? LayoutNodeIndex
        {
            get;
            set;
        }
        /// <summary>
        /// Document URL that `Document` or `FrameOwner` node points to.
        ///</summary>
        [JsonPropertyName("documentURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DocumentURL
        {
            get;
            set;
        }
        /// <summary>
        /// Base URL that `Document` or `FrameOwner` node uses for URL completion.
        ///</summary>
        [JsonPropertyName("baseURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BaseURL
        {
            get;
            set;
        }
        /// <summary>
        /// Only set for documents, contains the document's content language.
        ///</summary>
        [JsonPropertyName("contentLanguage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ContentLanguage
        {
            get;
            set;
        }
        /// <summary>
        /// Only set for documents, contains the document's character set encoding.
        ///</summary>
        [JsonPropertyName("documentEncoding")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DocumentEncoding
        {
            get;
            set;
        }
        /// <summary>
        /// `DocumentType` node's publicId.
        ///</summary>
        [JsonPropertyName("publicId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PublicId
        {
            get;
            set;
        }
        /// <summary>
        /// `DocumentType` node's systemId.
        ///</summary>
        [JsonPropertyName("systemId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SystemId
        {
            get;
            set;
        }
        /// <summary>
        /// Frame ID for frame owner elements and also for the document node.
        ///</summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// The index of a frame owner element's content document in the `domNodes` array returned by
        /// `getSnapshot`, if any.
        ///</summary>
        [JsonPropertyName("contentDocumentIndex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ContentDocumentIndex
        {
            get;
            set;
        }
        /// <summary>
        /// Type of a pseudo element node.
        ///</summary>
        [JsonPropertyName("pseudoType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.PseudoType? PseudoType
        {
            get;
            set;
        }
        /// <summary>
        /// Shadow root type.
        ///</summary>
        [JsonPropertyName("shadowRootType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.ShadowRootType? ShadowRootType
        {
            get;
            set;
        }
        /// <summary>
        /// Whether this DOM node responds to mouse clicks. This includes nodes that have had click
        /// event listeners attached via JavaScript as well as anchor tags that naturally navigate when
        /// clicked.
        ///</summary>
        [JsonPropertyName("isClickable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsClickable
        {
            get;
            set;
        }
        /// <summary>
        /// Details of the node's event listeners, if any.
        ///</summary>
        [JsonPropertyName("eventListeners")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOMDebugger.EventListener[] EventListeners
        {
            get;
            set;
        }
        /// <summary>
        /// The selected url for nodes with a srcset attribute.
        ///</summary>
        [JsonPropertyName("currentSourceURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string CurrentSourceURL
        {
            get;
            set;
        }
        /// <summary>
        /// The url of the script (if any) that generates this node.
        ///</summary>
        [JsonPropertyName("originURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string OriginURL
        {
            get;
            set;
        }
        /// <summary>
        /// Scroll offsets, set when this node is a Document.
        ///</summary>
        [JsonPropertyName("scrollOffsetX")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? ScrollOffsetX
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the scrollOffsetY
        /// </summary>
        [JsonPropertyName("scrollOffsetY")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? ScrollOffsetY
        {
            get;
            set;
        }
    }
}