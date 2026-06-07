namespace Zu.ChromeDevTools.DOMStorage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DomStorageItemsClearedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the storageId
        /// </summary>
        [JsonPropertyName("storageId")]
        public StorageId StorageId
        {
            get;
            set;
        }
    }
}