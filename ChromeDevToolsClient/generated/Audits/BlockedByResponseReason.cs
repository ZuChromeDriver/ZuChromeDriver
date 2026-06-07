namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enum indicating the reason a response has been blocked. These reasons are
    /// refinements of the net error BLOCKED_BY_RESPONSE.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BlockedByResponseReason
    {
        [JsonStringEnumMemberName("CoepFrameResourceNeedsCoepHeader")]
        CoepFrameResourceNeedsCoepHeader,
        [JsonStringEnumMemberName("CoopSandboxedIFrameCannotNavigateToCoopPage")]
        CoopSandboxedIFrameCannotNavigateToCoopPage,
        [JsonStringEnumMemberName("CorpNotSameOrigin")]
        CorpNotSameOrigin,
        [JsonStringEnumMemberName("CorpNotSameOriginAfterDefaultedToSameOriginByCoep")]
        CorpNotSameOriginAfterDefaultedToSameOriginByCoep,
        [JsonStringEnumMemberName("CorpNotSameOriginAfterDefaultedToSameOriginByDip")]
        CorpNotSameOriginAfterDefaultedToSameOriginByDip,
        [JsonStringEnumMemberName("CorpNotSameOriginAfterDefaultedToSameOriginByCoepAndDip")]
        CorpNotSameOriginAfterDefaultedToSameOriginByCoepAndDip,
        [JsonStringEnumMemberName("CorpNotSameSite")]
        CorpNotSameSite,
        [JsonStringEnumMemberName("SRIMessageSignatureMismatch")]
        SRIMessageSignatureMismatch,
    }
}