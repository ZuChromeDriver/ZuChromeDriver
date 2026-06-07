namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Session event details specific to refresh.
    /// </summary>
    public sealed class RefreshEventDetails
    {
        /// <summary>
        /// The result of a refresh.
        ///</summary>
        [JsonPropertyName("refreshResult")]
        public string RefreshResult
        {
            get;
            set;
        }
        /// <summary>
        /// If there was a fetch attempt, the result of that.
        ///</summary>
        [JsonPropertyName("fetchResult")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DeviceBoundSessionFetchResult? FetchResult
        {
            get;
            set;
        }
        /// <summary>
        /// The session display if there was a newly created session. This is populated
        /// for any refresh event that modifies the session config.
        ///</summary>
        [JsonPropertyName("newSession")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DeviceBoundSession NewSession
        {
            get;
            set;
        }
        /// <summary>
        /// See comments on `net::device_bound_sessions::RefreshEventResult::was_fully_proactive_refresh`.
        ///</summary>
        [JsonPropertyName("wasFullyProactiveRefresh")]
        public bool WasFullyProactiveRefresh
        {
            get;
            set;
        }
        /// <summary>
        /// Details about a failed device bound session network request if there was
        /// one.
        ///</summary>
        [JsonPropertyName("failedRequest")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DeviceBoundSessionFailedRequest FailedRequest
        {
            get;
            set;
        }
    }
}