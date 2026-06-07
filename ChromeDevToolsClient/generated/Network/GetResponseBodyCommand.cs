namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns content served for the given request.
    /// </summary>
    public sealed class GetResponseBodyCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.getResponseBody";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the network request to get content for.
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
    }

    public sealed class GetResponseBodyCommandResponse : ICommandResponse<GetResponseBodyCommand>
    {
        /// <summary>
        /// Response body.
        ///</summary>
        [JsonPropertyName("body")]
        public string Body
        {
            get;
            set;
        }
        /// <summary>
        /// True, if content was sent as base64.
        ///</summary>
        [JsonPropertyName("base64Encoded")]
        public bool Base64Encoded
        {
            get;
            set;
        }
    }
}