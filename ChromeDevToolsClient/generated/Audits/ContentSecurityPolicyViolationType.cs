namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContentSecurityPolicyViolationType
    {
        [JsonStringEnumMemberName("kInlineViolation")]
        KInlineViolation,
        [JsonStringEnumMemberName("kEvalViolation")]
        KEvalViolation,
        [JsonStringEnumMemberName("kURLViolation")]
        KURLViolation,
        [JsonStringEnumMemberName("kSRIViolation")]
        KSRIViolation,
        [JsonStringEnumMemberName("kTrustedTypesSinkViolation")]
        KTrustedTypesSinkViolation,
        [JsonStringEnumMemberName("kTrustedTypesPolicyViolation")]
        KTrustedTypesPolicyViolation,
        [JsonStringEnumMemberName("kWasmEvalViolation")]
        KWasmEvalViolation,
    }
}