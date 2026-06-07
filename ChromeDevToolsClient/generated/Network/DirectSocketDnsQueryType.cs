namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DirectSocketDnsQueryType
    {
        [JsonStringEnumMemberName("ipv4")]
        Ipv4,
        [JsonStringEnumMemberName("ipv6")]
        Ipv6,
    }
}