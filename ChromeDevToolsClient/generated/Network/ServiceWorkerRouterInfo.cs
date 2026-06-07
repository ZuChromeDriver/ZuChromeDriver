namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ServiceWorkerRouterInfo
    {
        /// <summary>
        /// ID of the rule matched. If there is a matched rule, this field will
        /// be set, otherwiser no value will be set.
        ///</summary>
        [JsonPropertyName("ruleIdMatched")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? RuleIdMatched
        {
            get;
            set;
        }
        /// <summary>
        /// The router source of the matched rule. If there is a matched rule, this
        /// field will be set, otherwise no value will be set.
        ///</summary>
        [JsonPropertyName("matchedSourceType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ServiceWorkerRouterSource? MatchedSourceType
        {
            get;
            set;
        }
        /// <summary>
        /// The actual router source used.
        ///</summary>
        [JsonPropertyName("actualSourceType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ServiceWorkerRouterSource? ActualSourceType
        {
            get;
            set;
        }
    }
}