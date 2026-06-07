namespace Zu.ChromeDevTools.Input
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Emitted only when `Input.setInterceptDrags` is enabled. Use this data with `Input.dispatchDragEvent` to
    /// restore normal drag and drop behavior.
    /// </summary>
    public sealed class DragInterceptedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the data
        /// </summary>
        [JsonPropertyName("data")]
        public DragData Data
        {
            get;
            set;
        }
    }
}