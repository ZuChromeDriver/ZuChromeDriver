namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the cookie's 'Priority' status:
    /// https://tools.ietf.org/html/draft-west-cookie-priority-00
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CookiePriority
    {
        [JsonStringEnumMemberName("Low")]
        Low,
        [JsonStringEnumMemberName("Medium")]
        Medium,
        [JsonStringEnumMemberName("High")]
        High,
    }
}