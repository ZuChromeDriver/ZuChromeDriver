namespace Zu.ChromeDevTools.WebMCP
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents the status of a tool invocation.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum InvocationStatus
    {
        [JsonStringEnumMemberName("Completed")]
        Completed,
        [JsonStringEnumMemberName("Canceled")]
        Canceled,
        [JsonStringEnumMemberName("Error")]
        Error,
    }
}