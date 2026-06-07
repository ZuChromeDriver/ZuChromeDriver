namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TrustTokenOperationType
    {
        [JsonStringEnumMemberName("Issuance")]
        Issuance,
        [JsonStringEnumMemberName("Redemption")]
        Redemption,
        [JsonStringEnumMemberName("Signing")]
        Signing,
    }
}