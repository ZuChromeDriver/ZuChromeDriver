namespace Zu.ChromeDevTools.DOMSnapshot
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Table containing nodes.
    /// </summary>
    public sealed class NodeTreeSnapshot
    {
        /// <summary>
        /// Parent node index.
        ///</summary>
        [JsonPropertyName("parentIndex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[] ParentIndex
        {
            get;
            set;
        }
        /// <summary>
        /// `Node`'s nodeType.
        ///</summary>
        [JsonPropertyName("nodeType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[] NodeType
        {
            get;
            set;
        }
        /// <summary>
        /// Type of the shadow root the `Node` is in. String values are equal to the `ShadowRootType` enum.
        ///</summary>
        [JsonPropertyName("shadowRootType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RareStringData ShadowRootType
        {
            get;
            set;
        }
        /// <summary>
        /// `Node`'s nodeName.
        ///</summary>
        [JsonPropertyName("nodeName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[] NodeName
        {
            get;
            set;
        }
        /// <summary>
        /// `Node`'s nodeValue.
        ///</summary>
        [JsonPropertyName("nodeValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[] NodeValue
        {
            get;
            set;
        }
        /// <summary>
        /// `Node`'s id, corresponds to DOM.Node.backendNodeId.
        ///</summary>
        [JsonPropertyName("backendNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[] BackendNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Attributes of an `Element` node. Flatten name, value pairs.
        ///</summary>
        [JsonPropertyName("attributes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[][] Attributes
        {
            get;
            set;
        }
        /// <summary>
        /// Only set for textarea elements, contains the text value.
        ///</summary>
        [JsonPropertyName("textValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RareStringData TextValue
        {
            get;
            set;
        }
        /// <summary>
        /// Only set for input elements, contains the input's associated text value.
        ///</summary>
        [JsonPropertyName("inputValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RareStringData InputValue
        {
            get;
            set;
        }
        /// <summary>
        /// Only set for radio and checkbox input elements, indicates if the element has been checked
        ///</summary>
        [JsonPropertyName("inputChecked")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RareBooleanData InputChecked
        {
            get;
            set;
        }
        /// <summary>
        /// Only set for option elements, indicates if the element has been selected
        ///</summary>
        [JsonPropertyName("optionSelected")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RareBooleanData OptionSelected
        {
            get;
            set;
        }
        /// <summary>
        /// The index of the document in the list of the snapshot documents.
        ///</summary>
        [JsonPropertyName("contentDocumentIndex")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RareIntegerData ContentDocumentIndex
        {
            get;
            set;
        }
        /// <summary>
        /// Type of a pseudo element node.
        ///</summary>
        [JsonPropertyName("pseudoType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RareStringData PseudoType
        {
            get;
            set;
        }
        /// <summary>
        /// Pseudo element identifier for this node. Only present if there is a
        /// valid pseudoType.
        ///</summary>
        [JsonPropertyName("pseudoIdentifier")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RareStringData PseudoIdentifier
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
        public RareBooleanData IsClickable
        {
            get;
            set;
        }
        /// <summary>
        /// The selected url for nodes with a srcset attribute.
        ///</summary>
        [JsonPropertyName("currentSourceURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RareStringData CurrentSourceURL
        {
            get;
            set;
        }
        /// <summary>
        /// The url of the script (if any) that generates this node.
        ///</summary>
        [JsonPropertyName("originURL")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RareStringData OriginURL
        {
            get;
            set;
        }
    }
}