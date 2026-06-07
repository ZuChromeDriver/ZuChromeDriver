namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Shared storage was accessed by the associated page.
    /// The following parameters are included in all events.
    /// </summary>
    public sealed class SharedStorageAccessedEvent : IEvent
    {
        /// <summary>
        /// Time of the access.
        /// </summary>
        [JsonPropertyName("accessTime")]
        public double AccessTime
        {
            get;
            set;
        }
        /// <summary>
        /// Enum value indicating the access scope.
        /// </summary>
        [JsonPropertyName("scope")]
        public SharedStorageAccessScope Scope
        {
            get;
            set;
        }
        /// <summary>
        /// Enum value indicating the Shared Storage API method invoked.
        /// </summary>
        [JsonPropertyName("method")]
        public SharedStorageAccessMethod Method
        {
            get;
            set;
        }
        /// <summary>
        /// DevTools Frame Token for the primary frame tree's root.
        /// </summary>
        [JsonPropertyName("mainFrameId")]
        public string MainFrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Serialization of the origin owning the Shared Storage data.
        /// </summary>
        [JsonPropertyName("ownerOrigin")]
        public string OwnerOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Serialization of the site owning the Shared Storage data.
        /// </summary>
        [JsonPropertyName("ownerSite")]
        public string OwnerSite
        {
            get;
            set;
        }
        /// <summary>
        /// The sub-parameters wrapped by `params` are all optional and their
        /// presence/absence depends on `type`.
        /// </summary>
        [JsonPropertyName("params")]
        public SharedStorageAccessParams Params
        {
            get;
            set;
        }
    }
}