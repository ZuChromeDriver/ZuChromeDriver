namespace Zu.ChromeDevTools.IO
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Read a chunk of the stream
    /// </summary>
    public sealed class ReadCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "IO.read";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Handle of the stream to read.
        /// </summary>
        [JsonPropertyName("handle")]
        public string Handle
        {
            get;
            set;
        }
        /// <summary>
        /// Seek to the specified offset before reading (if not specified, proceed with offset
        /// following the last read). Some types of streams may only support sequential reads.
        /// </summary>
        [JsonPropertyName("offset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Offset
        {
            get;
            set;
        }
        /// <summary>
        /// Maximum number of bytes to read (left upon the agent discretion if not specified).
        /// </summary>
        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Size
        {
            get;
            set;
        }
    }

    public sealed class ReadCommandResponse : ICommandResponse<ReadCommand>
    {
        /// <summary>
        /// Set if the data is base64-encoded
        ///</summary>
        [JsonPropertyName("base64Encoded")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Base64Encoded
        {
            get;
            set;
        }
        /// <summary>
        /// Data that were read.
        ///</summary>
        [JsonPropertyName("data")]
        public string Data
        {
            get;
            set;
        }
        /// <summary>
        /// Set if the end-of-file condition occurred while reading.
        ///</summary>
        [JsonPropertyName("eof")]
        public bool Eof
        {
            get;
            set;
        }
    }
}