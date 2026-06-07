namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS function at-rule representation.
    /// </summary>
    public sealed class CSSFunctionRule
    {
        /// <summary>
        /// Name of the function.
        ///</summary>
        [JsonPropertyName("name")]
        public Value Name
        {
            get;
            set;
        }
        /// <summary>
        /// The css style sheet identifier (absent for user agent stylesheet and user-specified
        /// stylesheet rules) this rule came from.
        ///</summary>
        [JsonPropertyName("styleSheetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string StyleSheetId
        {
            get;
            set;
        }
        /// <summary>
        /// Parent stylesheet's origin.
        ///</summary>
        [JsonPropertyName("origin")]
        public StyleSheetOrigin Origin
        {
            get;
            set;
        }
        /// <summary>
        /// List of parameters.
        ///</summary>
        [JsonPropertyName("parameters")]
        public CSSFunctionParameter[] Parameters
        {
            get;
            set;
        }
        /// <summary>
        /// Function body.
        ///</summary>
        [JsonPropertyName("children")]
        public CSSFunctionNode[] Children
        {
            get;
            set;
        }
        /// <summary>
        /// The BackendNodeId of the DOM node that constitutes the origin tree scope of this rule.
        ///</summary>
        [JsonPropertyName("originTreeScopeNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? OriginTreeScopeNodeId
        {
            get;
            set;
        }
    }
}