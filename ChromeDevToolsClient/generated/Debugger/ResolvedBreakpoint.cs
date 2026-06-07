namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ResolvedBreakpoint
    {
        /// <summary>
        /// Breakpoint unique identifier.
        ///</summary>
        [JsonPropertyName("breakpointId")]
        public string BreakpointId
        {
            get;
            set;
        }
        /// <summary>
        /// Actual breakpoint location.
        ///</summary>
        [JsonPropertyName("location")]
        public Location Location
        {
            get;
            set;
        }
    }
}