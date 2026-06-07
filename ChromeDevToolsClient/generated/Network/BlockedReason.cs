namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The reason why request was blocked.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BlockedReason
    {
        [JsonStringEnumMemberName("other")]
        Other,
        [JsonStringEnumMemberName("csp")]
        Csp,
        [JsonStringEnumMemberName("mixed-content")]
        MixedContent,
        [JsonStringEnumMemberName("origin")]
        Origin,
        [JsonStringEnumMemberName("inspector")]
        Inspector,
        [JsonStringEnumMemberName("integrity")]
        Integrity,
        [JsonStringEnumMemberName("subresource-filter")]
        SubresourceFilter,
        [JsonStringEnumMemberName("content-type")]
        ContentType,
        [JsonStringEnumMemberName("coep-frame-resource-needs-coep-header")]
        CoepFrameResourceNeedsCoepHeader,
        [JsonStringEnumMemberName("coop-sandboxed-iframe-cannot-navigate-to-coop-page")]
        CoopSandboxedIframeCannotNavigateToCoopPage,
        [JsonStringEnumMemberName("corp-not-same-origin")]
        CorpNotSameOrigin,
        [JsonStringEnumMemberName("corp-not-same-origin-after-defaulted-to-same-origin-by-coep")]
        CorpNotSameOriginAfterDefaultedToSameOriginByCoep,
        [JsonStringEnumMemberName("corp-not-same-origin-after-defaulted-to-same-origin-by-dip")]
        CorpNotSameOriginAfterDefaultedToSameOriginByDip,
        [JsonStringEnumMemberName("corp-not-same-origin-after-defaulted-to-same-origin-by-coep-and-dip")]
        CorpNotSameOriginAfterDefaultedToSameOriginByCoepAndDip,
        [JsonStringEnumMemberName("corp-not-same-site")]
        CorpNotSameSite,
        [JsonStringEnumMemberName("sri-message-signature-mismatch")]
        SriMessageSignatureMismatch,
    }
}