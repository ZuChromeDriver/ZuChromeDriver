namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A single Related Website Set object.
    /// </summary>
    public sealed class RelatedWebsiteSet
    {
        /// <summary>
        /// The primary site of this set, along with the ccTLDs if there is any.
        ///</summary>
        [JsonPropertyName("primarySites")]
        public string[] PrimarySites
        {
            get;
            set;
        }
        /// <summary>
        /// The associated sites of this set, along with the ccTLDs if there is any.
        ///</summary>
        [JsonPropertyName("associatedSites")]
        public string[] AssociatedSites
        {
            get;
            set;
        }
        /// <summary>
        /// The service sites of this set, along with the ccTLDs if there is any.
        ///</summary>
        [JsonPropertyName("serviceSites")]
        public string[] ServiceSites
        {
            get;
            set;
        }
    }
}