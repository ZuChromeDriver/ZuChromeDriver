namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Types of reasons why a cookie may not be sent with a request.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CookieBlockedReason
    {
        [JsonStringEnumMemberName("SecureOnly")]
        SecureOnly,
        [JsonStringEnumMemberName("NotOnPath")]
        NotOnPath,
        [JsonStringEnumMemberName("DomainMismatch")]
        DomainMismatch,
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
        [JsonStringEnumMemberName("PortMismatch")]
        PortMismatch,
        [JsonStringEnumMemberName("SchemeMismatch")]
        SchemeMismatch,
        [JsonStringEnumMemberName("AnonymousContext")]
        AnonymousContext,
    }
}