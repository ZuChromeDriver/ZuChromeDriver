namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IPAddressSpace
    {
        [JsonStringEnumMemberName("Loopback")]
        Loopback,
        [JsonStringEnumMemberName("Local")]
        Local,
        [JsonStringEnumMemberName("Public")]
        Public,
        [JsonStringEnumMemberName("Unknown")]
        Unknown,
    }
}