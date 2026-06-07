namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The type of preloading attempted. It corresponds to
    /// mojom::SpeculationAction (although PrefetchWithSubresources is omitted as it
    /// isn't being used by clients).
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SpeculationAction
    {
        [JsonStringEnumMemberName("Prefetch")]
        Prefetch,
        [JsonStringEnumMemberName("Prerender")]
        Prerender,
        [JsonStringEnumMemberName("PrerenderUntilScript")]
        PrerenderUntilScript,
    }
}