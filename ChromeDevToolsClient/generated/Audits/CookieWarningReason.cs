namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CookieWarningReason
    {
        [JsonStringEnumMemberName("WarnSameSiteUnspecifiedCrossSiteContext")]
        WarnSameSiteUnspecifiedCrossSiteContext,
        [JsonStringEnumMemberName("WarnSameSiteNoneInsecure")]
        WarnSameSiteNoneInsecure,
        [JsonStringEnumMemberName("WarnSameSiteUnspecifiedLaxAllowUnsafe")]
        WarnSameSiteUnspecifiedLaxAllowUnsafe,
        [JsonStringEnumMemberName("WarnSameSiteStrictLaxDowngradeStrict")]
        WarnSameSiteStrictLaxDowngradeStrict,
        [JsonStringEnumMemberName("WarnSameSiteStrictCrossDowngradeStrict")]
        WarnSameSiteStrictCrossDowngradeStrict,
        [JsonStringEnumMemberName("WarnSameSiteStrictCrossDowngradeLax")]
        WarnSameSiteStrictCrossDowngradeLax,
        [JsonStringEnumMemberName("WarnSameSiteLaxCrossDowngradeStrict")]
        WarnSameSiteLaxCrossDowngradeStrict,
        [JsonStringEnumMemberName("WarnSameSiteLaxCrossDowngradeLax")]
        WarnSameSiteLaxCrossDowngradeLax,
        [JsonStringEnumMemberName("WarnAttributeValueExceedsMaxSize")]
        WarnAttributeValueExceedsMaxSize,
        [JsonStringEnumMemberName("WarnDomainNonASCII")]
        WarnDomainNonASCII,
        [JsonStringEnumMemberName("WarnThirdPartyPhaseout")]
        WarnThirdPartyPhaseout,
        [JsonStringEnumMemberName("WarnCrossSiteRedirectDowngradeChangesInclusion")]
        WarnCrossSiteRedirectDowngradeChangesInclusion,
        [JsonStringEnumMemberName("WarnDeprecationTrialMetadata")]
        WarnDeprecationTrialMetadata,
        [JsonStringEnumMemberName("WarnThirdPartyCookieHeuristic")]
        WarnThirdPartyCookieHeuristic,
    }
}