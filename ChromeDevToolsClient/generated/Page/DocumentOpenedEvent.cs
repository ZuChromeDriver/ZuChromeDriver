namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when opening document to write to.
    /// </summary>
    public sealed class DocumentOpenedEvent : IEvent
    {
        /// <summary>
        /// Frame object.
        /// </summary>
        [JsonPropertyName("frame")]
        public Frame Frame
        {
            get;
            set;
        }
    }
}