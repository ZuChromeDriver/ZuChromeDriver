namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This issue warns about errors in property rules that lead to property
    /// registrations being ignored.
    /// </summary>
    public sealed class PropertyRuleIssueDetails
    {
        /// <summary>
        /// Source code position of the property rule.
        ///</summary>
        [JsonPropertyName("sourceCodeLocation")]
        public SourceCodeLocation SourceCodeLocation
        {
            get;
            set;
        }
        /// <summary>
        /// Reason why the property rule was discarded.
        ///</summary>
        [JsonPropertyName("propertyRuleIssueReason")]
        public PropertyRuleIssueReason PropertyRuleIssueReason
        {
            get;
            set;
        }
        /// <summary>
        /// The value of the property rule property that failed to parse
        ///</summary>
        [JsonPropertyName("propertyValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PropertyValue
        {
            get;
            set;
        }
    }
}