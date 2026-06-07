namespace Zu.ChromeDevTools.FileSystem
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class BucketFileSystemLocator
    {
        /// <summary>
        /// Storage key
        ///</summary>
        [JsonPropertyName("storageKey")]
        public string StorageKey
        {
            get;
            set;
        }
        /// <summary>
        /// Bucket name. Not passing a `bucketName` will retrieve the default Bucket. (https://developer.mozilla.org/en-US/docs/Web/API/Storage_API#storage_buckets)
        ///</summary>
        [JsonPropertyName("bucketName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BucketName
        {
            get;
            set;
        }
        /// <summary>
        /// Path to the directory using each path component as an array item.
        ///</summary>
        [JsonPropertyName("pathComponents")]
        public string[] PathComponents
        {
            get;
            set;
        }
    }
}