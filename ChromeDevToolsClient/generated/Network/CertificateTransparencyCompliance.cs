namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Whether the request complied with Certificate Transparency policy.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CertificateTransparencyCompliance
    {
        [JsonStringEnumMemberName("unknown")]
        Unknown,
        [JsonStringEnumMemberName("not-compliant")]
        NotCompliant,
        [JsonStringEnumMemberName("compliant")]
        Compliant,
    }
}