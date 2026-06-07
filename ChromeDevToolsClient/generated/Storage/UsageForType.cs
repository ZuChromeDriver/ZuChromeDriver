namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Usage for a storage type.
    /// </summary>
    public sealed class UsageForType
    {
        /// <summary>
        /// Name of storage type.
        ///</summary>
        [JsonPropertyName("storageType")]
        public StorageType StorageType
        {
            get;
            set;
        }
        /// <summary>
        /// Storage usage (bytes).
        ///</summary>
        [JsonPropertyName("usage")]
        public double Usage
        {
            get;
            set;
        }
    }
}