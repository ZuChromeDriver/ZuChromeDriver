namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// advance: If the scheduler runs out of immediate work, the virtual time base may fast forward to
    /// allow the next delayed task (if any) to run; pause: The virtual time base may not advance;
    /// pauseIfNetworkFetchesPending: The virtual time base may not advance if there are any pending
    /// resource fetches.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum VirtualTimePolicy
    {
        [JsonStringEnumMemberName("advance")]
        Advance,
        [JsonStringEnumMemberName("pause")]
        Pause,
        [JsonStringEnumMemberName("pauseIfNetworkFetchesPending")]
        PauseIfNetworkFetchesPending,
    }
}