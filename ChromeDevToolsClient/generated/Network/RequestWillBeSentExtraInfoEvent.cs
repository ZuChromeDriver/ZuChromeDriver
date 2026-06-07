namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when additional information about a requestWillBeSent event is available from the
    /// network stack. Not every requestWillBeSent event will have an additional
    /// requestWillBeSentExtraInfo fired for it, and there is no guarantee whether requestWillBeSent
    /// or requestWillBeSentExtraInfo will be fired first for the same request.
    /// </summary>
    public sealed class RequestWillBeSentExtraInfoEvent : IEvent
    {
        /// <summary>
        /// Request identifier. Used to match this information to an existing requestWillBeSent event.
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
        /// <summary>
        /// A list of cookies potentially associated to the requested URL. This includes both cookies sent with
        /// the request and the ones not sent; the latter are distinguished by having blockedReasons field set.
        /// </summary>
        [JsonPropertyName("associatedCookies")]
        public AssociatedCookie[] AssociatedCookies
        {
            get;
            set;
        }
        /// <summary>
        /// Raw request headers as they will be sent over the wire.
        /// </summary>
        [JsonPropertyName("headers")]
        public Headers Headers
        {
            get;
            set;
        }
        /// <summary>
        /// Connection timing information for the request.
        /// </summary>
        [JsonPropertyName("connectTiming")]
        public ConnectTiming ConnectTiming
        {
            get;
            set;
        }
        /// <summary>
        /// How the request site's device bound sessions were used during this request.
        /// </summary>
        [JsonPropertyName("deviceBoundSessionUsages")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DeviceBoundSessionWithUsage[] DeviceBoundSessionUsages
        {
            get;
            set;
        }
        /// <summary>
        /// The client security state set for the request.
        /// </summary>
        [JsonPropertyName("clientSecurityState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ClientSecurityState ClientSecurityState
        {
            get;
            set;
        }
        /// <summary>
        /// Whether the site has partitioned cookies stored in a partition different than the current one.
        /// </summary>
        [JsonPropertyName("siteHasCookieInOtherPartition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? SiteHasCookieInOtherPartition
        {
            get;
            set;
        }
        /// <summary>
        /// The network conditions id if this request was affected by network conditions configured via
        /// emulateNetworkConditionsByRule.
        /// </summary>
        [JsonPropertyName("appliedNetworkConditionsId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string AppliedNetworkConditionsId
        {
            get;
            set;
        }
    }
}