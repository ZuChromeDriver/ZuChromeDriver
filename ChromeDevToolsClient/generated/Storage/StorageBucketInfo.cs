namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class StorageBucketInfo
    {
        /// <summary>
        /// Gets or sets the bucket
        /// </summary>
        [JsonPropertyName("bucket")]
        public StorageBucket Bucket
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the expiration
        /// </summary>
        [JsonPropertyName("expiration")]
        public double Expiration
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
        /// Gets or sets the persistent
        /// </summary>
        [JsonPropertyName("persistent")]
        public bool Persistent
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the durability
        /// </summary>
        [JsonPropertyName("durability")]
        public StorageBucketsDurability Durability
        {
            get;
            set;
        }
    }
}