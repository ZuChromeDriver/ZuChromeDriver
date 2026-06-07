namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The status of a Reporting API report.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReportStatus
    {
        [JsonStringEnumMemberName("Queued")]
        Queued,
        [JsonStringEnumMemberName("Pending")]
        Pending,
        [JsonStringEnumMemberName("MarkedForRemoval")]
        MarkedForRemoval,
        [JsonStringEnumMemberName("Success")]
        Success,
    }
}