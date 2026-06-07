namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Browser command ids used by executeBrowserCommand.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BrowserCommandId
    {
        [JsonStringEnumMemberName("openTabSearch")]
        OpenTabSearch,
        [JsonStringEnumMemberName("closeTabSearch")]
        CloseTabSearch,
        [JsonStringEnumMemberName("openGlic")]
        OpenGlic,
    }
}