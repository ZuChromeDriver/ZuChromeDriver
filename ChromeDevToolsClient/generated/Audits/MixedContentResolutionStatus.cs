namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MixedContentResolutionStatus
    {
        [JsonStringEnumMemberName("MixedContentBlocked")]
        MixedContentBlocked,
        [JsonStringEnumMemberName("MixedContentAutomaticallyUpgraded")]
        MixedContentAutomaticallyUpgraded,
        [JsonStringEnumMemberName("MixedContentWarning")]
        MixedContentWarning,
    }
}