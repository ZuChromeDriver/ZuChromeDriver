namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when breakpoint is resolved to an actual script and location.
    /// Deprecated in favor of `resolvedBreakpoints` in the `scriptParsed` event.
    /// </summary>
    public sealed class BreakpointResolvedEvent : IEvent
    {
        /// <summary>
        /// Breakpoint unique identifier.
        /// </summary>
        [JsonPropertyName("breakpointId")]
        public string BreakpointId
        {
            get;
            set;
        }
        /// <summary>
        /// Actual breakpoint location.
        /// </summary>
        [JsonPropertyName("location")]
        public Location Location
        {
            get;
            set;
        }
    }
}