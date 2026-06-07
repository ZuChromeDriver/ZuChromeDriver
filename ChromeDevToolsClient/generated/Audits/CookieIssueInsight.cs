namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about the suggested solution to a cookie issue.
    /// </summary>
    public sealed class CookieIssueInsight
    {
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [JsonPropertyName("type")]
        public InsightType Type
        {
            get;
            set;
        }
        /// <summary>
        /// Link to table entry in third-party cookie migration readiness list.
        ///</summary>
        [JsonPropertyName("tableEntryUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TableEntryUrl
        {
            get;
            set;
        }
    }
}