namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the cookie's 'SameSite' status:
    /// https://tools.ietf.org/html/draft-west-first-party-cookies
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CookieSameSite
    {
        [JsonStringEnumMemberName("Strict")]
        Strict,
        [JsonStringEnumMemberName("Lax")]
        Lax,
        [JsonStringEnumMemberName("None")]
        None,
    }
}