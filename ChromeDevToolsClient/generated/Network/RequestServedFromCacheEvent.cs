namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired if request ended up loading from cache.
    /// </summary>
    public sealed class RequestServedFromCacheEvent : IEvent
    {
        /// <summary>
        /// Request identifier.
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
    }
}