namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the category of insight that a cookie issue falls under.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InsightType
    {
        [JsonStringEnumMemberName("GitHubResource")]
        GitHubResource,
        [JsonStringEnumMemberName("GracePeriod")]
        GracePeriod,
        [JsonStringEnumMemberName("Heuristics")]
        Heuristics,
    }
}