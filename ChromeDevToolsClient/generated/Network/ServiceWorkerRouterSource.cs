namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Source of service worker router.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ServiceWorkerRouterSource
    {
        [JsonStringEnumMemberName("network")]
        Network,
        [JsonStringEnumMemberName("cache")]
        Cache,
        [JsonStringEnumMemberName("fetch-event")]
        FetchEvent,
        [JsonStringEnumMemberName("race-network-and-fetch-handler")]
        RaceNetworkAndFetchHandler,
        [JsonStringEnumMemberName("race-network-and-cache")]
        RaceNetworkAndCache,
    }
}