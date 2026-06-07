namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Javascript dialog type.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DialogType
    {
        [JsonStringEnumMemberName("alert")]
        Alert,
        [JsonStringEnumMemberName("confirm")]
        Confirm,
        [JsonStringEnumMemberName("prompt")]
        Prompt,
        [JsonStringEnumMemberName("beforeunload")]
        Beforeunload,
    }
}