namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum of AudioContextState from the spec
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContextState
    {
        [JsonStringEnumMemberName("suspended")]
        Suspended,
        [JsonStringEnumMemberName("running")]
        Running,
        [JsonStringEnumMemberName("closed")]
        Closed,
        [JsonStringEnumMemberName("interrupted")]
        Interrupted,
    }
}