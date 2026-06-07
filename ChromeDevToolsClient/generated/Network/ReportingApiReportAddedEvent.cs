namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Is sent whenever a new report is added.
    /// And after 'enableReportingApi' for all existing reports.
    /// </summary>
    public sealed class ReportingApiReportAddedEvent : IEvent
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