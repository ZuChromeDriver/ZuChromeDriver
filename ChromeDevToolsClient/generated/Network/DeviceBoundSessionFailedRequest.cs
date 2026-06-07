namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Details about a failed device bound session network request.
    /// </summary>
    public sealed class DeviceBoundSessionFailedRequest
    {
        /// <summary>
        /// The failed request URL.
        ///</summary>
        [JsonPropertyName("requestUrl")]
        public string RequestUrl
        {
            get;
            set;
        }
        /// <summary>
        /// The net error of the response if it was not OK.
        ///</summary>
        [JsonPropertyName("netError")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string NetError
        {
            get;
            set;
        }
        /// <summary>
        /// The response code if the net error was OK and the response code was not
        /// 200.
        ///</summary>
        [JsonPropertyName("responseError")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? ResponseError
        {
            get;
            set;
        }
        /// <summary>
        /// The body of the response if the net error was OK, the response code was
        /// not 200, and the response body was not empty.
        ///</summary>
        [JsonPropertyName("responseErrorBody")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ResponseErrorBody
        {
            get;
            set;
        }
    }
}