namespace Zu.ChromeDevTools.DOMStorage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DomStorageItemUpdatedEvent : IEvent
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
        /// <summary>
        /// Gets or sets the key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the oldValue
        /// </summary>
        [JsonPropertyName("oldValue")]
        public string OldValue
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the newValue
        /// </summary>
        [JsonPropertyName("newValue")]
        public string NewValue
        {
            get;
            set;
        }
    }
}