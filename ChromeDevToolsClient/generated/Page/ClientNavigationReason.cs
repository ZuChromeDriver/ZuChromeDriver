namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ClientNavigationReason
    {
        [JsonStringEnumMemberName("anchorClick")]
        AnchorClick,
        [JsonStringEnumMemberName("formSubmissionGet")]
        FormSubmissionGet,
        [JsonStringEnumMemberName("formSubmissionPost")]
        FormSubmissionPost,
        [JsonStringEnumMemberName("httpHeaderRefresh")]
        HttpHeaderRefresh,
        [JsonStringEnumMemberName("initialFrameNavigation")]
        InitialFrameNavigation,
        [JsonStringEnumMemberName("metaTagRefresh")]
        MetaTagRefresh,
        [JsonStringEnumMemberName("other")]
        Other,
        [JsonStringEnumMemberName("pageBlockInterstitial")]
        PageBlockInterstitial,
        [JsonStringEnumMemberName("reload")]
        Reload,
        [JsonStringEnumMemberName("scriptInitiated")]
        ScriptInitiated,
    }
}