namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Corresponds to SpeculationRuleSet
    /// </summary>
    public sealed class RuleSet
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// Identifies a document which the rule set is associated with.
        ///</summary>
        [JsonPropertyName("loaderId")]
        public string LoaderId
        {
            get;
            set;
        }
        /// <summary>
        /// Source text of JSON representing the rule set. If it comes from
        /// `<script>` tag, it is the textContent of the node. Note that it is
        /// a JSON for valid case.
        /// 
        /// See also:
        /// - https://wicg.github.io/nav-speculation/speculation-rules.html
        /// - https://github.com/WICG/nav-speculation/blob/main/triggers.md
        ///</summary>
        [JsonPropertyName("sourceText")]
        public string SourceText
        {
            get;
            set;
        }
        /// <summary>
        /// A speculation rule set is either added through an inline
        /// `<script>` tag or through an external resource via the
        /// 'Speculation-Rules' HTTP header. For the first case, we include
        /// the BackendNodeId of the relevant `<script>` tag. For the second
        /// case, we include the external URL where the rule set was loaded
        /// from, and also RequestId if Network domain is enabled.
        /// 
        /// See also:
        /// - https://wicg.github.io/nav-speculation/speculation-rules.html#speculation-rules-script
        /// - https://wicg.github.io/nav-speculation/speculation-rules.html#speculation-rules-header
        ///</summary>
        [JsonPropertyName("backendNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BackendNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the url
        /// </summary>
        [JsonPropertyName("url")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the requestId
        /// </summary>
        [JsonPropertyName("requestId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RequestId
        {
            get;
            set;
        }
        /// <summary>
        /// Error information
        /// `errorMessage` is null iff `errorType` is null.
        ///</summary>
        [JsonPropertyName("errorType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RuleSetErrorType? ErrorType
        {
            get;
            set;
        }
        /// <summary>
        /// TODO(https://crbug.com/1425354): Replace this property with structured error.
        ///</summary>
        [JsonPropertyName("errorMessage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ErrorMessage
        {
            get;
            set;
        }
        /// <summary>
        /// For more details, see:
        /// https://github.com/WICG/nav-speculation/blob/main/speculation-rules-tags.md
        ///</summary>
        [JsonPropertyName("tag")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Tag
        {
            get;
            set;
        }
    }
}