namespace Zu.ChromeDevTools.DOMDebugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSP Violation type.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CSPViolationType
    {
        [JsonStringEnumMemberName("trustedtype-sink-violation")]
        TrustedtypeSinkViolation,
        [JsonStringEnumMemberName("trustedtype-policy-violation")]
        TrustedtypePolicyViolation,
    }
}