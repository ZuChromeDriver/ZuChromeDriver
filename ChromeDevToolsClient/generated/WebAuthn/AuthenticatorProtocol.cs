namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AuthenticatorProtocol
    {
        [JsonStringEnumMemberName("u2f")]
        U2f,
        [JsonStringEnumMemberName("ctap2")]
        Ctap2,
    }
}