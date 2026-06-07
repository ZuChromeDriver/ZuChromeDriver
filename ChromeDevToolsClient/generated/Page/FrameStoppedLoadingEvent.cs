namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when frame has stopped loading.
    /// </summary>
    public sealed class FrameStoppedLoadingEvent : IEvent
    {
        /// <summary>
        /// Id of the frame that has stopped loading.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
    }
}