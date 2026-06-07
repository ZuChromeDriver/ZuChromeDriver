namespace Zu.ChromeDevTools.Preload
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Lists sources for a preloading attempt, specifically the ids of rule sets
    /// that had a speculation rule that triggered the attempt, and the
    /// BackendNodeIds of <a href> or <area href> elements that triggered the
    /// attempt (in the case of attempts triggered by a document rule). It is
    /// possible for multiple rule sets and links to trigger a single attempt.
    /// </summary>
    public sealed class PreloadingAttemptSource
    {
        /// <summary>
        /// Gets or sets the key
        /// </summary>
        [JsonPropertyName("key")]
        public PreloadingAttemptKey Key
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the ruleSetIds
        /// </summary>
        [JsonPropertyName("ruleSetIds")]
        public string[] RuleSetIds
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the nodeIds
        /// </summary>
        [JsonPropertyName("nodeIds")]
        public long[] NodeIds
        {
            get;
            set;
        }
    }
}