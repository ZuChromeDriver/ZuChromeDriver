namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the response body and size if it were re-encoded with the specified settings. Only
    /// applies to images.
    /// </summary>
    public sealed class GetEncodedResponseCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Audits.getEncodedResponse";
        
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
        /// <summary>
        /// The encoding to use.
        /// </summary>
        [JsonPropertyName("encoding")]
        public string Encoding
        {
            get;
            set;
        }
        /// <summary>
        /// The quality of the encoding (0-1). (defaults to 1)
        /// </summary>
        [JsonPropertyName("quality")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Quality
        {
            get;
            set;
        }
        /// <summary>
        /// Whether to only return the size information (defaults to false).
        /// </summary>
        [JsonPropertyName("sizeOnly")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? SizeOnly
        {
            get;
            set;
        }
    }

    public sealed class GetEncodedResponseCommandResponse : ICommandResponse<GetEncodedResponseCommand>
    {
        /// <summary>
        /// The encoded body as a base64 string. Omitted if sizeOnly is true. (Encoded as a base64 string when passed over JSON)
        ///</summary>
        [JsonPropertyName("body")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Body
        {
            get;
            set;
        }
        /// <summary>
        /// Size before re-encoding.
        ///</summary>
        [JsonPropertyName("originalSize")]
        public long OriginalSize
        {
            get;
            set;
        }
        /// <summary>
        /// Size after re-encoding.
        ///</summary>
        [JsonPropertyName("encodedSize")]
        public long EncodedSize
        {
            get;
            set;
        }
    }
}