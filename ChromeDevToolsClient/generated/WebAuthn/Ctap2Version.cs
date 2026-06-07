namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Ctap2Version
    {
        [JsonStringEnumMemberName("ctap2_0")]
        Ctap2_0,
        [JsonStringEnumMemberName("ctap2_1")]
        Ctap2_1,
        [JsonStringEnumMemberName("ctap2_2")]
        Ctap2_2,
    }
}