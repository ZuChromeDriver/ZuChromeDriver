namespace Zu.ChromeDevTools.Fetch
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class RequestPattern
    {
        /// <summary>
        /// Wildcards (`'*'` -> zero or more, `'?'` -> exactly one) are allowed. Escape character is
        /// backslash. Omitting is equivalent to `"*"`.
        ///</summary>
        [JsonPropertyName("urlPattern")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UrlPattern
        {
            get;
            set;
        }
        /// <summary>
        /// If set, only requests for matching resource types will be intercepted.
        ///</summary>
        [JsonPropertyName("resourceType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Network.ResourceType? ResourceType
        {
            get;
            set;
        }
        /// <summary>
        /// Stage at which to begin intercepting requests. Default is Request.
        ///</summary>
        [JsonPropertyName("requestStage")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public RequestStage? RequestStage
        {
            get;
            set;
        }
    }
}