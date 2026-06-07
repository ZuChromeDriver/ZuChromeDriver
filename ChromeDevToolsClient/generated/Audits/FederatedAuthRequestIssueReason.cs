namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the failure reason when a federated authentication reason fails.
    /// Should be updated alongside RequestIdTokenStatus in
    /// third_party/blink/public/mojom/devtools/inspector_issue.mojom to include
    /// all cases except for success.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FederatedAuthRequestIssueReason
    {
        [JsonStringEnumMemberName("ShouldEmbargo")]
        ShouldEmbargo,
        [JsonStringEnumMemberName("TooManyRequests")]
        TooManyRequests,
        [JsonStringEnumMemberName("WellKnownHttpNotFound")]
        WellKnownHttpNotFound,
        [JsonStringEnumMemberName("WellKnownNoResponse")]
        WellKnownNoResponse,
        [JsonStringEnumMemberName("WellKnownInvalidResponse")]
        WellKnownInvalidResponse,
        [JsonStringEnumMemberName("WellKnownListEmpty")]
        WellKnownListEmpty,
        [JsonStringEnumMemberName("WellKnownInvalidContentType")]
        WellKnownInvalidContentType,
        [JsonStringEnumMemberName("ConfigNotInWellKnown")]
        ConfigNotInWellKnown,
        [JsonStringEnumMemberName("WellKnownTooBig")]
        WellKnownTooBig,
        [JsonStringEnumMemberName("ConfigHttpNotFound")]
        ConfigHttpNotFound,
        [JsonStringEnumMemberName("ConfigNoResponse")]
        ConfigNoResponse,
        [JsonStringEnumMemberName("ConfigInvalidResponse")]
        ConfigInvalidResponse,
        [JsonStringEnumMemberName("ConfigInvalidContentType")]
        ConfigInvalidContentType,
        [JsonStringEnumMemberName("IdpNotPotentiallyTrustworthy")]
        IdpNotPotentiallyTrustworthy,
        [JsonStringEnumMemberName("DisabledInSettings")]
        DisabledInSettings,
        [JsonStringEnumMemberName("DisabledInFlags")]
        DisabledInFlags,
        [JsonStringEnumMemberName("ErrorFetchingSignin")]
        ErrorFetchingSignin,
        [JsonStringEnumMemberName("InvalidSigninResponse")]
        InvalidSigninResponse,
        [JsonStringEnumMemberName("AccountsHttpNotFound")]
        AccountsHttpNotFound,
        [JsonStringEnumMemberName("AccountsNoResponse")]
        AccountsNoResponse,
        [JsonStringEnumMemberName("AccountsInvalidResponse")]
        AccountsInvalidResponse,
        [JsonStringEnumMemberName("AccountsListEmpty")]
        AccountsListEmpty,
        [JsonStringEnumMemberName("AccountsInvalidContentType")]
        AccountsInvalidContentType,
        [JsonStringEnumMemberName("IdTokenHttpNotFound")]
        IdTokenHttpNotFound,
        [JsonStringEnumMemberName("IdTokenNoResponse")]
        IdTokenNoResponse,
        [JsonStringEnumMemberName("IdTokenInvalidResponse")]
        IdTokenInvalidResponse,
        [JsonStringEnumMemberName("IdTokenIdpErrorResponse")]
        IdTokenIdpErrorResponse,
        [JsonStringEnumMemberName("IdTokenCrossSiteIdpErrorResponse")]
        IdTokenCrossSiteIdpErrorResponse,
        [JsonStringEnumMemberName("IdTokenInvalidRequest")]
        IdTokenInvalidRequest,
        [JsonStringEnumMemberName("IdTokenInvalidContentType")]
        IdTokenInvalidContentType,
        [JsonStringEnumMemberName("ErrorIdToken")]
        ErrorIdToken,
        [JsonStringEnumMemberName("Canceled")]
        Canceled,
        [JsonStringEnumMemberName("RpPageNotVisible")]
        RpPageNotVisible,
        [JsonStringEnumMemberName("SilentMediationFailure")]
        SilentMediationFailure,
        [JsonStringEnumMemberName("NotSignedInWithIdp")]
        NotSignedInWithIdp,
        [JsonStringEnumMemberName("MissingTransientUserActivation")]
        MissingTransientUserActivation,
        [JsonStringEnumMemberName("ReplacedByActiveMode")]
        ReplacedByActiveMode,
        [JsonStringEnumMemberName("RelyingPartyOriginIsOpaque")]
        RelyingPartyOriginIsOpaque,
        [JsonStringEnumMemberName("TypeNotMatching")]
        TypeNotMatching,
        [JsonStringEnumMemberName("UiDismissedNoEmbargo")]
        UiDismissedNoEmbargo,
        [JsonStringEnumMemberName("CorsError")]
        CorsError,
        [JsonStringEnumMemberName("SuppressedBySegmentationPlatform")]
        SuppressedBySegmentationPlatform,
    }
}