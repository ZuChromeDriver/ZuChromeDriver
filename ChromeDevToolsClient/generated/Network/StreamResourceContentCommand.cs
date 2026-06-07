namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enables streaming of the response for the given requestId.
    /// If enabled, the dataReceived event contains the data that was received during streaming.
    /// </summary>
    public sealed class StreamResourceContentCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.streamResourceContent";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the request to stream.
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
    }

    public sealed class StreamResourceContentCommandResponse : ICommandResponse<StreamResourceContentCommand>
    {
        /// <summary>
        /// Data that has been buffered until streaming is enabled. (Encoded as a base64 string when passed over JSON)
        ///</summary>
        [JsonPropertyName("bufferedData")]
        public string BufferedData
        {
            get;
            set;
        }
    }
}