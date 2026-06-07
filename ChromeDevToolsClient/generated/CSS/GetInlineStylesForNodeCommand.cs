namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the styles defined inline (explicitly in the "style" attribute and implicitly, using DOM
    /// attributes) for a DOM node identified by `nodeId`.
    /// </summary>
    public sealed class GetInlineStylesForNodeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.getInlineStylesForNode";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the nodeId
        /// </summary>
        [JsonPropertyName("nodeId")]
        public long NodeId
        {
            get;
            set;
        }
    }

    public sealed class GetInlineStylesForNodeCommandResponse : ICommandResponse<GetInlineStylesForNodeCommand>
    {
        /// <summary>
        /// Inline style for the specified DOM node.
        ///</summary>
        [JsonPropertyName("inlineStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSStyle InlineStyle
        {
            get;
            set;
        }
        /// <summary>
        /// Attribute-defined element style (e.g. resulting from "width=20 height=100%").
        ///</summary>
        [JsonPropertyName("attributesStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSStyle AttributesStyle
        {
            get;
            set;
        }
    }
}