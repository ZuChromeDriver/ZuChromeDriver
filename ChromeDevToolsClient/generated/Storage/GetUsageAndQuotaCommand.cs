namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns usage and quota in bytes.
    /// </summary>
    public sealed class GetUsageAndQuotaCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.getUsageAndQuota";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Security origin.
        /// </summary>
        [JsonPropertyName("origin")]
        public string Origin
        {
            get;
            set;
        }
    }

    public sealed class GetUsageAndQuotaCommandResponse : ICommandResponse<GetUsageAndQuotaCommand>
    {
        /// <summary>
        /// Storage usage (bytes).
        ///</summary>
        [JsonPropertyName("usage")]
        public double Usage
        {
            get;
            set;
        }
        /// <summary>
        /// Storage quota (bytes).
        ///</summary>
        [JsonPropertyName("quota")]
        public double Quota
        {
            get;
            set;
        }
        /// <summary>
        /// Whether or not the origin has an active storage quota override
        ///</summary>
        [JsonPropertyName("overrideActive")]
        public bool OverrideActive
        {
            get;
            set;
        }
        /// <summary>
        /// Storage usage per type (bytes).
        ///</summary>
        [JsonPropertyName("usageBreakdown")]
        public UsageForType[] UsageBreakdown
        {
            get;
            set;
        }
    }
}