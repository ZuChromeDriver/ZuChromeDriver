namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContentSecurityPolicySource
    {
        [JsonStringEnumMemberName("HTTP")]
        HTTP,
        [JsonStringEnumMemberName("Meta")]
        Meta,
    }
}