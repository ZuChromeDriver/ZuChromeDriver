namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ClientNavigationDisposition
    {
        [JsonStringEnumMemberName("currentTab")]
        CurrentTab,
        [JsonStringEnumMemberName("newTab")]
        NewTab,
        [JsonStringEnumMemberName("newWindow")]
        NewWindow,
        [JsonStringEnumMemberName("download")]
        Download,
    }
}