namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The reason why request was blocked.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CorsError
    {
        [JsonStringEnumMemberName("DisallowedByMode")]
        DisallowedByMode,
        [JsonStringEnumMemberName("InvalidResponse")]
        InvalidResponse,
        [JsonStringEnumMemberName("WildcardOriginNotAllowed")]
        WildcardOriginNotAllowed,
        [JsonStringEnumMemberName("MissingAllowOriginHeader")]
        MissingAllowOriginHeader,
        [JsonStringEnumMemberName("MultipleAllowOriginValues")]
        MultipleAllowOriginValues,
        [JsonStringEnumMemberName("InvalidAllowOriginValue")]
        InvalidAllowOriginValue,
        [JsonStringEnumMemberName("AllowOriginMismatch")]
        AllowOriginMismatch,
        [JsonStringEnumMemberName("InvalidAllowCredentials")]
        InvalidAllowCredentials,
        [JsonStringEnumMemberName("CorsDisabledScheme")]
        CorsDisabledScheme,
        [JsonStringEnumMemberName("PreflightInvalidStatus")]
        PreflightInvalidStatus,
        [JsonStringEnumMemberName("PreflightDisallowedRedirect")]
        PreflightDisallowedRedirect,
        [JsonStringEnumMemberName("PreflightWildcardOriginNotAllowed")]
        PreflightWildcardOriginNotAllowed,
        [JsonStringEnumMemberName("PreflightMissingAllowOriginHeader")]
        PreflightMissingAllowOriginHeader,
        [JsonStringEnumMemberName("PreflightMultipleAllowOriginValues")]
        PreflightMultipleAllowOriginValues,
        [JsonStringEnumMemberName("PreflightInvalidAllowOriginValue")]
        PreflightInvalidAllowOriginValue,
        [JsonStringEnumMemberName("PreflightAllowOriginMismatch")]
        PreflightAllowOriginMismatch,
        [JsonStringEnumMemberName("PreflightInvalidAllowCredentials")]
        PreflightInvalidAllowCredentials,
        [JsonStringEnumMemberName("PreflightMissingAllowExternal")]
        PreflightMissingAllowExternal,
        [JsonStringEnumMemberName("PreflightInvalidAllowExternal")]
        PreflightInvalidAllowExternal,
        [JsonStringEnumMemberName("InvalidAllowMethodsPreflightResponse")]
        InvalidAllowMethodsPreflightResponse,
        [JsonStringEnumMemberName("InvalidAllowHeadersPreflightResponse")]
        InvalidAllowHeadersPreflightResponse,
        [JsonStringEnumMemberName("MethodDisallowedByPreflightResponse")]
        MethodDisallowedByPreflightResponse,
        [JsonStringEnumMemberName("HeaderDisallowedByPreflightResponse")]
        HeaderDisallowedByPreflightResponse,
        [JsonStringEnumMemberName("RedirectContainsCredentials")]
        RedirectContainsCredentials,
        [JsonStringEnumMemberName("InsecureLocalNetwork")]
        InsecureLocalNetwork,
        [JsonStringEnumMemberName("InvalidLocalNetworkAccess")]
        InvalidLocalNetworkAccess,
        [JsonStringEnumMemberName("NoCorsRedirectModeNotFollow")]
        NoCorsRedirectModeNotFollow,
        [JsonStringEnumMemberName("LocalNetworkAccessPermissionDenied")]
        LocalNetworkAccessPermissionDenied,
    }
}