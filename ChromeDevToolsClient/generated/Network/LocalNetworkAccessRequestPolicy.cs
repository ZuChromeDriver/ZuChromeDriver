namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LocalNetworkAccessRequestPolicy
    {
        [JsonStringEnumMemberName("Allow")]
        Allow,
        [JsonStringEnumMemberName("BlockFromInsecureToMorePrivate")]
        BlockFromInsecureToMorePrivate,
        [JsonStringEnumMemberName("WarnFromInsecureToMorePrivate")]
        WarnFromInsecureToMorePrivate,
        [JsonStringEnumMemberName("PermissionBlock")]
        PermissionBlock,
        [JsonStringEnumMemberName("PermissionWarn")]
        PermissionWarn,
    }
}