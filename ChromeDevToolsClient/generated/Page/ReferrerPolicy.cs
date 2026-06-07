namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The referring-policy used for the navigation.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ReferrerPolicy
    {
        [JsonStringEnumMemberName("noReferrer")]
        NoReferrer,
        [JsonStringEnumMemberName("noReferrerWhenDowngrade")]
        NoReferrerWhenDowngrade,
        [JsonStringEnumMemberName("origin")]
        Origin,
        [JsonStringEnumMemberName("originWhenCrossOrigin")]
        OriginWhenCrossOrigin,
        [JsonStringEnumMemberName("sameOrigin")]
        SameOrigin,
        [JsonStringEnumMemberName("strictOrigin")]
        StrictOrigin,
        [JsonStringEnumMemberName("strictOriginWhenCrossOrigin")]
        StrictOriginWhenCrossOrigin,
        [JsonStringEnumMemberName("unsafeUrl")]
        UnsafeUrl,
    }
}