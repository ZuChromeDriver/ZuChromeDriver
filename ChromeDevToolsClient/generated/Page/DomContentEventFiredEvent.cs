namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DomContentEventFiredEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the timestamp
        /// </summary>
        [JsonPropertyName("timestamp")]
        public double Timestamp
        {
            get;
            set;
        }
    }
}