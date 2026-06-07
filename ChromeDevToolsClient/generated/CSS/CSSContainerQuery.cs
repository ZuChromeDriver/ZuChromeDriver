namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS container query rule descriptor.
    /// </summary>
    public sealed class CSSContainerQuery
    {
        /// <summary>
        /// Container query text.
        /// Contains the query part without the container name for a single query.
        /// Deprecated in favor of conditionText which contains the full prelude
        /// after @container.
        ///</summary>
        [JsonPropertyName("text")]
        public string Text
        {
            get;
            set;
        }
        /// <summary>
        /// The associated rule header range in the enclosing stylesheet (if
        /// available).
        ///</summary>
        [JsonPropertyName("range")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SourceRange Range
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the stylesheet containing this object (if exists).
        ///</summary>
        [JsonPropertyName("styleSheetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string StyleSheetId
        {
            get;
            set;
        }
        /// <summary>
        /// Optional name for the container.
        ///</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Optional physical axes queried for the container.
        ///</summary>
        [JsonPropertyName("physicalAxes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.PhysicalAxes? PhysicalAxes
        {
            get;
            set;
        }
        /// <summary>
        /// Optional logical axes queried for the container.
        ///</summary>
        [JsonPropertyName("logicalAxes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.LogicalAxes? LogicalAxes
        {
            get;
            set;
        }
        /// <summary>
        /// true if the query contains scroll-state() queries.
        ///</summary>
        [JsonPropertyName("queriesScrollState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? QueriesScrollState
        {
            get;
            set;
        }
        /// <summary>
        /// true if the query contains anchored() queries.
        ///</summary>
        [JsonPropertyName("queriesAnchored")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? QueriesAnchored
        {
            get;
            set;
        }
        /// <summary>
        /// CSSContainerRule.conditionText
        ///</summary>
        [JsonPropertyName("conditionText")]
        public string ConditionText
        {
            get;
            set;
        }
    }
}