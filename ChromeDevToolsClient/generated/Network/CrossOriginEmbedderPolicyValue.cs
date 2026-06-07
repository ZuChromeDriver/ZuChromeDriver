namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CrossOriginEmbedderPolicyValue
    {
        [JsonStringEnumMemberName("None")]
        None,
        [JsonStringEnumMemberName("Credentialless")]
        Credentialless,
        [JsonStringEnumMemberName("RequireCorp")]
        RequireCorp,
    }
}