namespace Zu.ChromeDevTools.PWA
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// If user prefers opening the app in browser or an app window.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DisplayMode
    {
        [JsonStringEnumMemberName("standalone")]
        Standalone,
        [JsonStringEnumMemberName("browser")]
        Browser,
    }
}