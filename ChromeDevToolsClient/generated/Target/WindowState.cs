namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The state of the target window.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WindowState
    {
        [JsonStringEnumMemberName("normal")]
        Normal,
        [JsonStringEnumMemberName("minimized")]
        Minimized,
        [JsonStringEnumMemberName("maximized")]
        Maximized,
        [JsonStringEnumMemberName("fullscreen")]
        Fullscreen,
    }
}