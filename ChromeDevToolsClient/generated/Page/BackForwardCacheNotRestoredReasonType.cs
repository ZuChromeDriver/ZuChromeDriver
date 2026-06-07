namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Types of not restored reasons for back-forward cache.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BackForwardCacheNotRestoredReasonType
    {
        [JsonStringEnumMemberName("SupportPending")]
        SupportPending,
        [JsonStringEnumMemberName("PageSupportNeeded")]
        PageSupportNeeded,
        [JsonStringEnumMemberName("Circumstantial")]
        Circumstantial,
    }
}