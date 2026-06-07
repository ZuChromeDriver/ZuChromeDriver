namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class PartitioningBlobURLIssueDetails
    {
        /// <summary>
        /// The BlobURL that failed to load.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Additional information about the Partitioning Blob URL issue.
        ///</summary>
        [JsonPropertyName("partitioningBlobURLInfo")]
        public PartitioningBlobURLInfo PartitioningBlobURLInfo
        {
            get;
            set;
        }
    }
}