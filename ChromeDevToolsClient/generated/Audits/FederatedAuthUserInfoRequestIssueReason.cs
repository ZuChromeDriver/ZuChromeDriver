namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the failure reason when a getUserInfo() call fails.
    /// Should be updated alongside FederatedAuthUserInfoRequestResult in
    /// third_party/blink/public/mojom/devtools/inspector_issue.mojom.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FederatedAuthUserInfoRequestIssueReason
    {
        [JsonStringEnumMemberName("NotSameOrigin")]
        NotSameOrigin,
        [JsonStringEnumMemberName("NotIframe")]
        NotIframe,
        [JsonStringEnumMemberName("NotPotentiallyTrustworthy")]
        NotPotentiallyTrustworthy,
        [JsonStringEnumMemberName("NoApiPermission")]
        NoApiPermission,
        [JsonStringEnumMemberName("NotSignedInWithIdp")]
        NotSignedInWithIdp,
        [JsonStringEnumMemberName("NoAccountSharingPermission")]
        NoAccountSharingPermission,
        [JsonStringEnumMemberName("InvalidConfigOrWellKnown")]
        InvalidConfigOrWellKnown,
        [JsonStringEnumMemberName("InvalidAccountsResponse")]
        InvalidAccountsResponse,
        [JsonStringEnumMemberName("NoReturningUserFromFetchedAccounts")]
        NoReturningUserFromFetchedAccounts,
    }
}