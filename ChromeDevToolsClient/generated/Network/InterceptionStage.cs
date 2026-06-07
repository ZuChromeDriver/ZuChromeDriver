namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Stages of the interception to begin intercepting. Request will intercept before the request is
    /// sent. Response will intercept after the response is received.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InterceptionStage
    {
        [JsonStringEnumMemberName("Request")]
        Request,
        [JsonStringEnumMemberName("HeadersReceived")]
        HeadersReceived,
    }
}