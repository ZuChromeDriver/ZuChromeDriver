namespace Zu.ChromeDevTools.FedCm
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The types of FedCM dialogs.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DialogType
    {
        [JsonStringEnumMemberName("AccountChooser")]
        AccountChooser,
        [JsonStringEnumMemberName("AutoReauthn")]
        AutoReauthn,
        [JsonStringEnumMemberName("ConfirmIdpLogin")]
        ConfirmIdpLogin,
        [JsonStringEnumMemberName("Error")]
        Error,
    }
}