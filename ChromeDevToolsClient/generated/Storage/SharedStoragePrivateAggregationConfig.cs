namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a dictionary object passed in as privateAggregationConfig to
    /// run or selectURL.
    /// </summary>
    public sealed class SharedStoragePrivateAggregationConfig
    {
        /// <summary>
        /// The chosen aggregation service deployment.
        ///</summary>
        [JsonPropertyName("aggregationCoordinatorOrigin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string AggregationCoordinatorOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// The context ID provided.
        ///</summary>
        [JsonPropertyName("contextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ContextId
        {
            get;
            set;
        }
        /// <summary>
        /// Configures the maximum size allowed for filtering IDs.
        ///</summary>
        [JsonPropertyName("filteringIdMaxBytes")]
        public long FilteringIdMaxBytes
        {
            get;
            set;
        }
        /// <summary>
        /// The limit on the number of contributions in the final report.
        ///</summary>
        [JsonPropertyName("maxContributions")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? MaxContributions
        {
            get;
            set;
        }
    }
}