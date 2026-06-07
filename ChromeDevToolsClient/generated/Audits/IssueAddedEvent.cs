namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class IssueAddedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the issue
        /// </summary>
        [JsonPropertyName("issue")]
        public InspectorIssue Issue
        {
            get;
            set;
        }
    }
}