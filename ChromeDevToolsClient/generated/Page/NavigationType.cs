namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The type of a frameNavigated event.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NavigationType
    {
        [JsonStringEnumMemberName("Navigation")]
        Navigation,
        [JsonStringEnumMemberName("BackForwardCacheRestore")]
        BackForwardCacheRestore,
    }
}