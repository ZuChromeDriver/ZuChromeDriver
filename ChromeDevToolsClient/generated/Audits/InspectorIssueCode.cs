namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A unique identifier for the type of issue. Each type may use one of the
    /// optional fields in InspectorIssueDetails to convey more specific
    /// information about the kind of issue.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InspectorIssueCode
    {
        [JsonStringEnumMemberName("CookieIssue")]
        CookieIssue,
        [JsonStringEnumMemberName("MixedContentIssue")]
        MixedContentIssue,
        [JsonStringEnumMemberName("BlockedByResponseIssue")]
        BlockedByResponseIssue,
        [JsonStringEnumMemberName("HeavyAdIssue")]
        HeavyAdIssue,
        [JsonStringEnumMemberName("ContentSecurityPolicyIssue")]
        ContentSecurityPolicyIssue,
        [JsonStringEnumMemberName("SharedArrayBufferIssue")]
        SharedArrayBufferIssue,
        [JsonStringEnumMemberName("CorsIssue")]
        CorsIssue,
        [JsonStringEnumMemberName("AttributionReportingIssue")]
        AttributionReportingIssue,
        [JsonStringEnumMemberName("QuirksModeIssue")]
        QuirksModeIssue,
        [JsonStringEnumMemberName("PartitioningBlobURLIssue")]
        PartitioningBlobURLIssue,
        [JsonStringEnumMemberName("NavigatorUserAgentIssue")]
        NavigatorUserAgentIssue,
        [JsonStringEnumMemberName("GenericIssue")]
        GenericIssue,
        [JsonStringEnumMemberName("DeprecationIssue")]
        DeprecationIssue,
        [JsonStringEnumMemberName("ClientHintIssue")]
        ClientHintIssue,
        [JsonStringEnumMemberName("FederatedAuthRequestIssue")]
        FederatedAuthRequestIssue,
        [JsonStringEnumMemberName("BounceTrackingIssue")]
        BounceTrackingIssue,
        [JsonStringEnumMemberName("CookieDeprecationMetadataIssue")]
        CookieDeprecationMetadataIssue,
        [JsonStringEnumMemberName("StylesheetLoadingIssue")]
        StylesheetLoadingIssue,
        [JsonStringEnumMemberName("FederatedAuthUserInfoRequestIssue")]
        FederatedAuthUserInfoRequestIssue,
        [JsonStringEnumMemberName("PropertyRuleIssue")]
        PropertyRuleIssue,
        [JsonStringEnumMemberName("SharedDictionaryIssue")]
        SharedDictionaryIssue,
        [JsonStringEnumMemberName("ElementAccessibilityIssue")]
        ElementAccessibilityIssue,
        [JsonStringEnumMemberName("SRIMessageSignatureIssue")]
        SRIMessageSignatureIssue,
        [JsonStringEnumMemberName("UnencodedDigestIssue")]
        UnencodedDigestIssue,
        [JsonStringEnumMemberName("ConnectionAllowlistIssue")]
        ConnectionAllowlistIssue,
        [JsonStringEnumMemberName("UserReidentificationIssue")]
        UserReidentificationIssue,
        [JsonStringEnumMemberName("PermissionElementIssue")]
        PermissionElementIssue,
        [JsonStringEnumMemberName("PerformanceIssue")]
        PerformanceIssue,
        [JsonStringEnumMemberName("SelectivePermissionsInterventionIssue")]
        SelectivePermissionsInterventionIssue,
    }
}