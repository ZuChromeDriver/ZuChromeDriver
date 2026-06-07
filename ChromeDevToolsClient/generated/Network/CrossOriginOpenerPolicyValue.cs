namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CrossOriginOpenerPolicyValue
    {
        [JsonStringEnumMemberName("SameOrigin")]
        SameOrigin,
        [JsonStringEnumMemberName("SameOriginAllowPopups")]
        SameOriginAllowPopups,
        [JsonStringEnumMemberName("RestrictProperties")]
        RestrictProperties,
        [JsonStringEnumMemberName("UnsafeNone")]
        UnsafeNone,
        [JsonStringEnumMemberName("SameOriginPlusCoep")]
        SameOriginPlusCoep,
        [JsonStringEnumMemberName("RestrictPropertiesPlusCoep")]
        RestrictPropertiesPlusCoep,
        [JsonStringEnumMemberName("NoopenerAllowPopups")]
        NoopenerAllowPopups,
    }
}