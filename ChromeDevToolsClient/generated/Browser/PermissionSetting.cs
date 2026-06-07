namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PermissionSetting
    {
        [JsonStringEnumMemberName("granted")]
        Granted,
        [JsonStringEnumMemberName("denied")]
        Denied,
        [JsonStringEnumMemberName("prompt")]
        Prompt,
    }
}