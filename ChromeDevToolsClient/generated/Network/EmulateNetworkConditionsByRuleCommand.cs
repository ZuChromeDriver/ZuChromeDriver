namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Activates emulation of network conditions for individual requests using URL match patterns. Unlike the deprecated
    /// Network.emulateNetworkConditions this method does not affect `navigator` state. Use Network.overrideNetworkState to
    /// explicitly modify `navigator` behavior.
    /// </summary>
    public sealed class EmulateNetworkConditionsByRuleCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Network.emulateNetworkConditionsByRule";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// True to emulate internet disconnection. Deprecated, use the offline property in matchedNetworkConditions
        /// or emulateOfflineServiceWorker instead.
        /// </summary>
        [JsonPropertyName("offline")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Offline
        {
            get;
            set;
        }
        /// <summary>
        /// True to emulate offline service worker.
        /// </summary>
        [JsonPropertyName("emulateOfflineServiceWorker")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? EmulateOfflineServiceWorker
        {
            get;
            set;
        }
        /// <summary>
        /// Configure conditions for matching requests. If multiple entries match a request, the first entry wins.  Global
        /// conditions can be configured by leaving the urlPattern for the conditions empty. These global conditions are
        /// also applied for throttling of p2p connections.
        /// </summary>
        [JsonPropertyName("matchedNetworkConditions")]
        public NetworkConditions[] MatchedNetworkConditions
        {
            get;
            set;
        }
    }

    public sealed class EmulateNetworkConditionsByRuleCommandResponse : ICommandResponse<EmulateNetworkConditionsByRuleCommand>
    {
        /// <summary>
        /// An id for each entry in matchedNetworkConditions. The id will be included in the requestWillBeSentExtraInfo for
        /// requests affected by a rule.
        ///</summary>
        [JsonPropertyName("ruleIds")]
        public string[] RuleIds
        {
            get;
            set;
        }
    }
}