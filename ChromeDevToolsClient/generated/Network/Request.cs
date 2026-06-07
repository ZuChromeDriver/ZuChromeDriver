namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// HTTP request data.
    /// </summary>
    public sealed class Request
    {
        /// <summary>
        /// Request URL (without fragment).
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Fragment of the requested URL starting with hash, if present.
        ///</summary>
        [JsonPropertyName("urlFragment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UrlFragment
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP request method.
        ///</summary>
        [JsonPropertyName("method")]
        public string Method
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP request headers.
        ///</summary>
        [JsonPropertyName("headers")]
        public Headers Headers
        {
            get;
            set;
        }
        /// <summary>
        /// HTTP POST request data.
        /// Use postDataEntries instead.
        ///</summary>
        [JsonPropertyName("postData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PostData
        {
            get;
            set;
        }
        /// <summary>
        /// True when the request has POST data. Note that postData might still be omitted when this flag is true when the data is too long.
        ///</summary>
        [JsonPropertyName("hasPostData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? HasPostData
        {
            get;
            set;
        }
        /// <summary>
        /// Request body elements (post data broken into individual entries).
        ///</summary>
        [JsonPropertyName("postDataEntries")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PostDataEntry[] PostDataEntries
        {
            get;
            set;
        }
        /// <summary>
        /// The mixed content type of the request.
        ///</summary>
        [JsonPropertyName("mixedContentType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Security.MixedContentType? MixedContentType
        {
            get;
            set;
        }
        /// <summary>
        /// Priority of the resource request at the time request is sent.
        ///</summary>
        [JsonPropertyName("initialPriority")]
        public ResourcePriority InitialPriority
        {
            get;
            set;
        }
        /// <summary>
        /// The referrer policy of the request, as defined in https://www.w3.org/TR/referrer-policy/
        ///</summary>
        [JsonPropertyName("referrerPolicy")]
        public string ReferrerPolicy
        {
            get;
            set;
        }
        /// <summary>
        /// Whether is loaded via link preload.
        ///</summary>
        [JsonPropertyName("isLinkPreload")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsLinkPreload
        {
            get;
            set;
        }
        /// <summary>
        /// Set for requests when the TrustToken API is used. Contains the parameters
        /// passed by the developer (e.g. via "fetch") as understood by the backend.
        ///</summary>
        [JsonPropertyName("trustTokenParams")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public TrustTokenParams TrustTokenParams
        {
            get;
            set;
        }
        /// <summary>
        /// True if this resource request is considered to be the 'same site' as the
        /// request corresponding to the main frame.
        ///</summary>
        [JsonPropertyName("isSameSite")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsSameSite
        {
            get;
            set;
        }
        /// <summary>
        /// True when the resource request is ad-related.
        ///</summary>
        [JsonPropertyName("isAdRelated")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? IsAdRelated
        {
            get;
            set;
        }
    }
}