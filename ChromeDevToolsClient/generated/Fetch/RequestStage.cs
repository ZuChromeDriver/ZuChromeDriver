namespace Zu.ChromeDevTools.Fetch
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Stages of the request to handle. Request will intercept before the request is
    /// sent. Response will intercept after the response is received (but before response
    /// body is received).
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RequestStage
    {
        [JsonStringEnumMemberName("Request")]
        Request,
        [JsonStringEnumMemberName("Response")]
        Response,
    }
}