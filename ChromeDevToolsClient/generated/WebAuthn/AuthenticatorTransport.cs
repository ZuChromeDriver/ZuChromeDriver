namespace Zu.ChromeDevTools.WebAuthn
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AuthenticatorTransport
    {
        [JsonStringEnumMemberName("usb")]
        Usb,
        [JsonStringEnumMemberName("nfc")]
        Nfc,
        [JsonStringEnumMemberName("ble")]
        Ble,
        [JsonStringEnumMemberName("cable")]
        Cable,
        [JsonStringEnumMemberName("internal")]
        Internal,
    }
}