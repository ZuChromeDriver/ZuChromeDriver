namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Types of reasons why a cookie may not be stored from a response.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SetCookieBlockedReason
    {
        [JsonStringEnumMemberName("SecureOnly")]
        SecureOnly,
        [JsonStringEnumMemberName("SameSiteStrict")]
        SameSiteStrict,
        [JsonStringEnumMemberName("SameSiteLax")]
        SameSiteLax,
        [JsonStringEnumMemberName("SameSiteUnspecifiedTreatedAsLax")]
        SameSiteUnspecifiedTreatedAsLax,
        [JsonStringEnumMemberName("SameSiteNoneInsecure")]
        SameSiteNoneInsecure,
        [JsonStringEnumMemberName("UserPreferences")]
        UserPreferences,
        [JsonStringEnumMemberName("ThirdPartyPhaseout")]
        ThirdPartyPhaseout,
        [JsonStringEnumMemberName("ThirdPartyBlockedInFirstPartySet")]
        ThirdPartyBlockedInFirstPartySet,
        [JsonStringEnumMemberName("SyntaxError")]
        SyntaxError,
        [JsonStringEnumMemberName("SchemeNotSupported")]
        SchemeNotSupported,
        [JsonStringEnumMemberName("OverwriteSecure")]
        OverwriteSecure,
        [JsonStringEnumMemberName("InvalidDomain")]
        InvalidDomain,
        [JsonStringEnumMemberName("InvalidPrefix")]
        InvalidPrefix,
        [JsonStringEnumMemberName("UnknownError")]
        UnknownError,
        [JsonStringEnumMemberName("SchemefulSameSiteStrict")]
        SchemefulSameSiteStrict,
        [JsonStringEnumMemberName("SchemefulSameSiteLax")]
        SchemefulSameSiteLax,
        [JsonStringEnumMemberName("SchemefulSameSiteUnspecifiedTreatedAsLax")]
        SchemefulSameSiteUnspecifiedTreatedAsLax,
        [JsonStringEnumMemberName("NameValuePairExceedsMaxSize")]
        NameValuePairExceedsMaxSize,
        [JsonStringEnumMemberName("DisallowedCharacter")]
        DisallowedCharacter,
        [JsonStringEnumMemberName("NoCookieContent")]
        NoCookieContent,
    }
}