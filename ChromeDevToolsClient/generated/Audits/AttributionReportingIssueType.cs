namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AttributionReportingIssueType
    {
        [JsonStringEnumMemberName("PermissionPolicyDisabled")]
        PermissionPolicyDisabled,
        [JsonStringEnumMemberName("UntrustworthyReportingOrigin")]
        UntrustworthyReportingOrigin,
        [JsonStringEnumMemberName("InsecureContext")]
        InsecureContext,
        [JsonStringEnumMemberName("InvalidHeader")]
        InvalidHeader,
        [JsonStringEnumMemberName("InvalidRegisterTriggerHeader")]
        InvalidRegisterTriggerHeader,
        [JsonStringEnumMemberName("SourceAndTriggerHeaders")]
        SourceAndTriggerHeaders,
        [JsonStringEnumMemberName("SourceIgnored")]
        SourceIgnored,
        [JsonStringEnumMemberName("TriggerIgnored")]
        TriggerIgnored,
        [JsonStringEnumMemberName("OsSourceIgnored")]
        OsSourceIgnored,
        [JsonStringEnumMemberName("OsTriggerIgnored")]
        OsTriggerIgnored,
        [JsonStringEnumMemberName("InvalidRegisterOsSourceHeader")]
        InvalidRegisterOsSourceHeader,
        [JsonStringEnumMemberName("InvalidRegisterOsTriggerHeader")]
        InvalidRegisterOsTriggerHeader,
        [JsonStringEnumMemberName("WebAndOsHeaders")]
        WebAndOsHeaders,
        [JsonStringEnumMemberName("NoWebOrOsSupport")]
        NoWebOrOsSupport,
        [JsonStringEnumMemberName("NavigationRegistrationWithoutTransientUserActivation")]
        NavigationRegistrationWithoutTransientUserActivation,
        [JsonStringEnumMemberName("InvalidInfoHeader")]
        InvalidInfoHeader,
        [JsonStringEnumMemberName("NoRegisterSourceHeader")]
        NoRegisterSourceHeader,
        [JsonStringEnumMemberName("NoRegisterTriggerHeader")]
        NoRegisterTriggerHeader,
        [JsonStringEnumMemberName("NoRegisterOsSourceHeader")]
        NoRegisterOsSourceHeader,
        [JsonStringEnumMemberName("NoRegisterOsTriggerHeader")]
        NoRegisterOsTriggerHeader,
        [JsonStringEnumMemberName("NavigationRegistrationUniqueScopeAlreadySet")]
        NavigationRegistrationUniqueScopeAlreadySet,
    }
}