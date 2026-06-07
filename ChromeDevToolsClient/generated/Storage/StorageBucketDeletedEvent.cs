namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class StorageBucketDeletedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the bucketId
        /// </summary>
        [JsonPropertyName("bucketId")]
        public string BucketId
        {
            get;
            set;
        }
    }
}