namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CookieExclusionReason
    {
        [JsonStringEnumMemberName("ExcludeSameSiteUnspecifiedTreatedAsLax")]
        ExcludeSameSiteUnspecifiedTreatedAsLax,
        [JsonStringEnumMemberName("ExcludeSameSiteNoneInsecure")]
        ExcludeSameSiteNoneInsecure,
        [JsonStringEnumMemberName("ExcludeSameSiteLax")]
        ExcludeSameSiteLax,
        [JsonStringEnumMemberName("ExcludeSameSiteStrict")]
        ExcludeSameSiteStrict,
        [JsonStringEnumMemberName("ExcludeDomainNonASCII")]
        ExcludeDomainNonASCII,
        [JsonStringEnumMemberName("ExcludeThirdPartyCookieBlockedInFirstPartySet")]
        ExcludeThirdPartyCookieBlockedInFirstPartySet,
        [JsonStringEnumMemberName("ExcludeThirdPartyPhaseout")]
        ExcludeThirdPartyPhaseout,
        [JsonStringEnumMemberName("ExcludePortMismatch")]
        ExcludePortMismatch,
        [JsonStringEnumMemberName("ExcludeSchemeMismatch")]
        ExcludeSchemeMismatch,
    }
}