namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Section of the body of a CSS function rule.
    /// </summary>
    public sealed class CSSFunctionNode
    {
        /// <summary>
        /// A conditional block. If set, style should not be set.
        ///</summary>
        [JsonPropertyName("condition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSFunctionConditionNode Condition
        {
            get;
            set;
        }
        /// <summary>
        /// Values set by this node. If set, condition should not be set.
        ///</summary>
        [JsonPropertyName("style")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSStyle Style
        {
            get;
            set;
        }
    }
}