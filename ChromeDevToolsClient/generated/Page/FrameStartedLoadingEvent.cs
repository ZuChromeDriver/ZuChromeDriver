namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when frame has started loading.
    /// </summary>
    public sealed class FrameStartedLoadingEvent : IEvent
    {
        /// <summary>
        /// Id of the frame that has started loading.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
    }
}