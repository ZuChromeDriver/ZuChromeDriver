namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CookieOperation
    {
        [JsonStringEnumMemberName("SetCookie")]
        SetCookie,
        [JsonStringEnumMemberName("ReadCookie")]
        ReadCookie,
    }
}