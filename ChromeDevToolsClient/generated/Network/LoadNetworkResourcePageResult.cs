namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// An object providing the result of a network resource load.
    /// </summary>
    public sealed class LoadNetworkResourcePageResult
    {
        /// <summary>
        /// Gets or sets the success
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success
        {
            get;
            set;
        }
        /// <summary>
        /// Optional values used for error reporting.
        ///</summary>
        [JsonPropertyName("netError")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? NetError
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the netErrorName
        /// </summary>
        [JsonPropertyName("netErrorName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string NetErrorName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the httpStatusCode
        /// </summary>
        [JsonPropertyName("httpStatusCode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? HttpStatusCode
        {
            get;
            set;
        }
        /// <summary>
        /// If successful, one of the following two fields holds the result.
        ///</summary>
        [JsonPropertyName("stream")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Stream
        {
            get;
            set;
        }
        /// <summary>
        /// Response headers.
        ///</summary>
        [JsonPropertyName("headers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Network.Headers Headers
        {
            get;
            set;
        }
    }
}