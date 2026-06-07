namespace Zu.ChromeDevTools.PerformanceTimeline
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// See https://wicg.github.io/layout-instability/#sec-layout-shift and layout_shift.idl
    /// </summary>
    public sealed class LayoutShift
    {
        /// <summary>
        /// Score increment produced by this event.
        ///</summary>
        [JsonPropertyName("value")]
        public double Value
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the hadRecentInput
        /// </summary>
        [JsonPropertyName("hadRecentInput")]
        public bool HadRecentInput
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the lastInputTime
        /// </summary>
        [JsonPropertyName("lastInputTime")]
        public double LastInputTime
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the sources
        /// </summary>
        [JsonPropertyName("sources")]
        public LayoutShiftAttribution[] Sources
        {
            get;
            set;
        }
    }
}