namespace Zu.ChromeDevTools.Tracing
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Details exposed when memory request explicitly declared.
    /// Keep consistent with memory_dump_request_args.h and
    /// memory_instrumentation.mojom
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MemoryDumpLevelOfDetail
    {
        [JsonStringEnumMemberName("background")]
        Background,
        [JsonStringEnumMemberName("light")]
        Light,
        [JsonStringEnumMemberName("detailed")]
        Detailed,
    }
}