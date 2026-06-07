namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ReportingApiReportUpdatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the report
        /// </summary>
        [JsonPropertyName("report")]
        public ReportingApiReport Report
        {
            get;
            set;
        }
    }
}