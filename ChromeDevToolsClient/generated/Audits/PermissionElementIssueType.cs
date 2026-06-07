namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PermissionElementIssueType
    {
        [JsonStringEnumMemberName("InvalidType")]
        InvalidType,
        [JsonStringEnumMemberName("FencedFrameDisallowed")]
        FencedFrameDisallowed,
        [JsonStringEnumMemberName("CspFrameAncestorsMissing")]
        CspFrameAncestorsMissing,
        [JsonStringEnumMemberName("PermissionsPolicyBlocked")]
        PermissionsPolicyBlocked,
        [JsonStringEnumMemberName("PaddingRightUnsupported")]
        PaddingRightUnsupported,
        [JsonStringEnumMemberName("PaddingBottomUnsupported")]
        PaddingBottomUnsupported,
        [JsonStringEnumMemberName("InsetBoxShadowUnsupported")]
        InsetBoxShadowUnsupported,
        [JsonStringEnumMemberName("RequestInProgress")]
        RequestInProgress,
        [JsonStringEnumMemberName("UntrustedEvent")]
        UntrustedEvent,
        [JsonStringEnumMemberName("RegistrationFailed")]
        RegistrationFailed,
        [JsonStringEnumMemberName("TypeNotSupported")]
        TypeNotSupported,
        [JsonStringEnumMemberName("InvalidTypeActivation")]
        InvalidTypeActivation,
        [JsonStringEnumMemberName("SecurityChecksFailed")]
        SecurityChecksFailed,
        [JsonStringEnumMemberName("ActivationDisabled")]
        ActivationDisabled,
        [JsonStringEnumMemberName("GeolocationDeprecated")]
        GeolocationDeprecated,
        [JsonStringEnumMemberName("InvalidDisplayStyle")]
        InvalidDisplayStyle,
        [JsonStringEnumMemberName("NonOpaqueColor")]
        NonOpaqueColor,
        [JsonStringEnumMemberName("LowContrast")]
        LowContrast,
        [JsonStringEnumMemberName("FontSizeTooSmall")]
        FontSizeTooSmall,
        [JsonStringEnumMemberName("FontSizeTooLarge")]
        FontSizeTooLarge,
        [JsonStringEnumMemberName("InvalidSizeValue")]
        InvalidSizeValue,
    }
}