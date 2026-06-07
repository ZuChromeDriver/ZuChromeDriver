namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the computed style for a DOM node identified by `nodeId`.
    /// </summary>
    public sealed class GetComputedStyleForNodeCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.getComputedStyleForNode";
        
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

    public sealed class GetComputedStyleForNodeCommandResponse : ICommandResponse<GetComputedStyleForNodeCommand>
    {
        /// <summary>
        /// Computed style for the specified DOM node.
        ///</summary>
        [JsonPropertyName("computedStyle")]
        public CSSComputedStyleProperty[] ComputedStyle
        {
            get;
            set;
        }
        /// <summary>
        /// A list of non-standard "extra fields" which blink stores alongside each
        /// computed style.
        ///</summary>
        [JsonPropertyName("extraFields")]
        public ComputedStyleExtraFields ExtraFields
        {
            get;
            set;
        }
    }
}