namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class CrossOriginEmbedderPolicyStatus
    {
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        [JsonPropertyName("value")]
        public CrossOriginEmbedderPolicyValue Value
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the reportOnlyValue
        /// </summary>
        [JsonPropertyName("reportOnlyValue")]
        public CrossOriginEmbedderPolicyValue ReportOnlyValue
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the reportingEndpoint
        /// </summary>
        [JsonPropertyName("reportingEndpoint")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ReportingEndpoint
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the reportOnlyReportingEndpoint
        /// </summary>
        [JsonPropertyName("reportOnlyReportingEndpoint")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ReportOnlyReportingEndpoint
        {
            get;
            set;
        }
    }
}