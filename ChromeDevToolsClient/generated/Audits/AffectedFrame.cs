namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about the frame affected by an inspector issue.
    /// </summary>
    public sealed class AffectedFrame
    {
        /// <summary>
        /// Gets or sets the frameId
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
    }
}