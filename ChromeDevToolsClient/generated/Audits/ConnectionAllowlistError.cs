namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ConnectionAllowlistError
    {
        [JsonStringEnumMemberName("InvalidHeader")]
        InvalidHeader,
        [JsonStringEnumMemberName("MoreThanOneList")]
        MoreThanOneList,
        [JsonStringEnumMemberName("ItemNotInnerList")]
        ItemNotInnerList,
        [JsonStringEnumMemberName("InvalidAllowlistItemType")]
        InvalidAllowlistItemType,
        [JsonStringEnumMemberName("ReportingEndpointNotToken")]
        ReportingEndpointNotToken,
        [JsonStringEnumMemberName("InvalidUrlPattern")]
        InvalidUrlPattern,
    }
}