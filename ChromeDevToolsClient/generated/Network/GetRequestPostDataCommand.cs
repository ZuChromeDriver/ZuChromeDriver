namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns post data sent with the request. Returns an error when no data was sent with the request.
    /// </summary>
    public sealed class GetRequestPostDataCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.getRequestPostData";
        
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

    public sealed class GetRequestPostDataCommandResponse : ICommandResponse<GetRequestPostDataCommand>
    {
        /// <summary>
        /// Request body string, omitting files from multipart requests
        ///</summary>
        [JsonPropertyName("postData")]
        public string PostData
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