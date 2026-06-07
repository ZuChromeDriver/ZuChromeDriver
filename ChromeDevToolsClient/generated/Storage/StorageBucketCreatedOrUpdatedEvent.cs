namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class StorageBucketCreatedOrUpdatedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the bucketInfo
        /// </summary>
        [JsonPropertyName("bucketInfo")]
        public StorageBucketInfo BucketInfo
        {
            get;
            set;
        }
    }
}