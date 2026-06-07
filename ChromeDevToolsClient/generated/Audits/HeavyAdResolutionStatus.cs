namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum HeavyAdResolutionStatus
    {
        [JsonStringEnumMemberName("HeavyAdBlocked")]
        HeavyAdBlocked,
        [JsonStringEnumMemberName("HeavyAdWarning")]
        HeavyAdWarning,
    }
}