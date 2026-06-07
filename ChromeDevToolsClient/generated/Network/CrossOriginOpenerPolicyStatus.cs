namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class CrossOriginOpenerPolicyStatus
    {
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        [JsonPropertyName("value")]
        public CrossOriginOpenerPolicyValue Value
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the reportOnlyValue
        /// </summary>
        [JsonPropertyName("reportOnlyValue")]
        public CrossOriginOpenerPolicyValue ReportOnlyValue
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