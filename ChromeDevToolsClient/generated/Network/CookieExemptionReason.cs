namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Types of reasons why a cookie should have been blocked by 3PCD but is exempted for the request.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CookieExemptionReason
    {
        [JsonStringEnumMemberName("None")]
        None,
        [JsonStringEnumMemberName("UserSetting")]
        UserSetting,
        [JsonStringEnumMemberName("TPCDMetadata")]
        TPCDMetadata,
        [JsonStringEnumMemberName("TPCDDeprecationTrial")]
        TPCDDeprecationTrial,
        [JsonStringEnumMemberName("TopLevelTPCDDeprecationTrial")]
        TopLevelTPCDDeprecationTrial,
        [JsonStringEnumMemberName("TPCDHeuristics")]
        TPCDHeuristics,
        [JsonStringEnumMemberName("EnterprisePolicy")]
        EnterprisePolicy,
        [JsonStringEnumMemberName("StorageAccess")]
        StorageAccess,
        [JsonStringEnumMemberName("TopLevelStorageAccess")]
        TopLevelStorageAccess,
        [JsonStringEnumMemberName("Scheme")]
        Scheme,
        [JsonStringEnumMemberName("SameSiteNoneCookiesInSandbox")]
        SameSiteNoneCookiesInSandbox,
    }
}