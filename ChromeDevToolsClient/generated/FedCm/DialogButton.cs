namespace Zu.ChromeDevTools.FedCm
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The buttons on the FedCM dialog.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DialogButton
    {
        [JsonStringEnumMemberName("ConfirmIdpLoginContinue")]
        ConfirmIdpLoginContinue,
        [JsonStringEnumMemberName("ErrorGotIt")]
        ErrorGotIt,
        [JsonStringEnumMemberName("ErrorMoreDetails")]
        ErrorMoreDetails,
    }
}