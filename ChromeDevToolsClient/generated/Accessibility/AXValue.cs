namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A single computed AX property.
    /// </summary>
    public sealed class AXValue
    {
        /// <summary>
        /// The type of this value.
        ///</summary>
        [JsonPropertyName("type")]
        public AXValueType Type
        {
            get;
            set;
        }
        /// <summary>
        /// The computed value of this property.
        ///</summary>
        [JsonPropertyName("value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public object Value
        {
            get;
            set;
        }
        /// <summary>
        /// One or more related nodes, if applicable.
        ///</summary>
        [JsonPropertyName("relatedNodes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AXRelatedNode[] RelatedNodes
        {
            get;
            set;
        }
        /// <summary>
        /// The sources which contributed to the computation of this property.
        ///</summary>
        [JsonPropertyName("sources")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AXValueSource[] Sources
        {
            get;
            set;
        }
    }
}