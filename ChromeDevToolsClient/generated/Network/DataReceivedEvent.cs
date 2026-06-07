namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when data chunk was received over the network.
    /// </summary>
    public sealed class DataReceivedEvent : IEvent
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
        /// Data chunk length.
        /// </summary>
        [JsonPropertyName("dataLength")]
        public long DataLength
        {
            get;
            set;
        }
        /// <summary>
        /// Actual bytes received (might be less than dataLength for compressed encodings).
        /// </summary>
        [JsonPropertyName("encodedDataLength")]
        public long EncodedDataLength
        {
            get;
            set;
        }
        /// <summary>
        /// Data that was received. (Encoded as a base64 string when passed over JSON)
        /// </summary>
        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Data
        {
            get;
            set;
        }
    }
}