namespace Zu.ChromeDevTools.Tracing
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Backend type to use for tracing. `chrome` uses the Chrome-integrated
    /// tracing service and is supported on all platforms. `system` is only
    /// supported on Chrome OS and uses the Perfetto system tracing service.
    /// `auto` chooses `system` when the perfettoConfig provided to Tracing.start
    /// specifies at least one non-Chrome data source; otherwise uses `chrome`.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TracingBackend
    {
        [JsonStringEnumMemberName("auto")]
        Auto,
        [JsonStringEnumMemberName("chrome")]
        Chrome,
        [JsonStringEnumMemberName("system")]
        System,
    }
}