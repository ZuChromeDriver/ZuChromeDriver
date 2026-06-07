namespace Zu.ChromeDevTools.Security
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The security level of a page or resource.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SecurityState
    {
        [JsonStringEnumMemberName("unknown")]
        Unknown,
        [JsonStringEnumMemberName("neutral")]
        Neutral,
        [JsonStringEnumMemberName("insecure")]
        Insecure,
        [JsonStringEnumMemberName("secure")]
        Secure,
        [JsonStringEnumMemberName("info")]
        Info,
        [JsonStringEnumMemberName("insecure-broken")]
        InsecureBroken,
    }
}