namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when HTTP request has finished loading.
    /// </summary>
    public sealed class LoadingFinishedEvent : IEvent
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
        /// <summary>
        /// Timestamp.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public double Timestamp
        {
            get;
            set;
        }
        /// <summary>
        /// Total number of bytes received for this request.
        /// </summary>
        [JsonPropertyName("encodedDataLength")]
        public double EncodedDataLength
        {
            get;
            set;
        }
    }
}