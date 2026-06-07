namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Preloading status values, see also PreloadingTriggeringOutcome. This
    /// status is shared by prefetchStatusUpdated and prerenderStatusUpdated.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PreloadingStatus
    {
        [JsonStringEnumMemberName("Pending")]
        Pending,
        [JsonStringEnumMemberName("Running")]
        Running,
        [JsonStringEnumMemberName("Ready")]
        Ready,
        [JsonStringEnumMemberName("Success")]
        Success,
        [JsonStringEnumMemberName("Failure")]
        Failure,
        [JsonStringEnumMemberName("NotSupported")]
        NotSupported,
    }
}