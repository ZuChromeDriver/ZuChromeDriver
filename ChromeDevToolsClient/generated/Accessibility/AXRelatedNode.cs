namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class AXRelatedNode
    {
        /// <summary>
        /// The BackendNodeId of the related DOM node.
        ///</summary>
        [JsonPropertyName("backendDOMNodeId")]
        public long BackendDOMNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// The IDRef value provided, if any.
        ///</summary>
        [JsonPropertyName("idref")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Idref
        {
            get;
            set;
        }
        /// <summary>
        /// The text alternative of this node in the current context.
        ///</summary>
        [JsonPropertyName("text")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Text
        {
            get;
            set;
        }
    }
}