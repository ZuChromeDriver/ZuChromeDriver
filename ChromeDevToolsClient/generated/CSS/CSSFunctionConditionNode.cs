namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS function conditional block representation.
    /// </summary>
    public sealed class CSSFunctionConditionNode
    {
        /// <summary>
        /// Media query for this conditional block. Only one type of condition should be set.
        ///</summary>
        [JsonPropertyName("media")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSMedia Media
        {
            get;
            set;
        }
        /// <summary>
        /// Container query for this conditional block. Only one type of condition should be set.
        ///</summary>
        [JsonPropertyName("containerQueries")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSContainerQuery ContainerQueries
        {
            get;
            set;
        }
        /// <summary>
        /// @supports CSS at-rule condition. Only one type of condition should be set.
        ///</summary>
        [JsonPropertyName("supports")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSSupports Supports
        {
            get;
            set;
        }
        /// <summary>
        /// @navigation condition. Only one type of condition should be set.
        ///</summary>
        [JsonPropertyName("navigation")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSNavigation Navigation
        {
            get;
            set;
        }
        /// <summary>
        /// Block body.
        ///</summary>
        [JsonPropertyName("children")]
        public CSSFunctionNode[] Children
        {
            get;
            set;
        }
        /// <summary>
        /// The condition text.
        ///</summary>
        [JsonPropertyName("conditionText")]
        public string ConditionText
        {
            get;
            set;
        }
    }
}