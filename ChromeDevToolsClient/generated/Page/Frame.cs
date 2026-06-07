namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about the Frame on the page.
    /// </summary>
    public sealed class Frame
    {
        /// <summary>
        /// Frame unique identifier.
        ///</summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// Parent frame identifier.
        ///</summary>
        [JsonPropertyName("parentId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ParentId
        {
            get;
            set;
        }
        /// <summary>
        /// Identifier of the loader associated with this frame.
        ///</summary>
        [JsonPropertyName("loaderId")]
        public string LoaderId
        {
            get;
            set;
        }
        /// <summary>
        /// Frame's name as specified in the tag.
        ///</summary>
        [JsonPropertyName("name")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Frame document's URL without fragment.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Frame document's URL fragment including the '#'.
        ///</summary>
        [JsonPropertyName("urlFragment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UrlFragment
        {
            get;
            set;
        }
        /// <summary>
        /// Frame document's registered domain, taking the public suffixes list into account.
        /// Extracted from the Frame's url.
        /// Example URLs: http://www.google.com/file.html -> "google.com"
        ///               http://a.b.co.uk/file.html      -> "b.co.uk"
        ///</summary>
        [JsonPropertyName("domainAndRegistry")]
        public string DomainAndRegistry
        {
            get;
            set;
        }
        /// <summary>
        /// Frame document's security origin.
        ///</summary>
        [JsonPropertyName("securityOrigin")]
        public string SecurityOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Additional details about the frame document's security origin.
        ///</summary>
        [JsonPropertyName("securityOriginDetails")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public SecurityOriginDetails SecurityOriginDetails
        {
            get;
            set;
        }
        /// <summary>
        /// Frame document's mimeType as determined by the browser.
        ///</summary>
        [JsonPropertyName("mimeType")]
        public string MimeType
        {
            get;
            set;
        }
        /// <summary>
        /// If the frame failed to load, this contains the URL that could not be loaded. Note that unlike url above, this URL may contain a fragment.
        ///</summary>
        [JsonPropertyName("unreachableUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string UnreachableUrl
        {
            get;
            set;
        }
        /// <summary>
        /// Indicates whether this frame was tagged as an ad and why.
        ///</summary>
        [JsonPropertyName("adFrameStatus")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AdFrameStatus AdFrameStatus
        {
            get;
            set;
        }
        /// <summary>
        /// Indicates whether the main document is a secure context and explains why that is the case.
        ///</summary>
        [JsonPropertyName("secureContextType")]
        public SecureContextType SecureContextType
        {
            get;
            set;
        }
        /// <summary>
        /// Indicates whether this is a cross origin isolated context.
        ///</summary>
        [JsonPropertyName("crossOriginIsolatedContextType")]
        public CrossOriginIsolatedContextType CrossOriginIsolatedContextType
        {
            get;
            set;
        }
        /// <summary>
        /// Indicated which gated APIs / features are available.
        ///</summary>
        [JsonPropertyName("gatedAPIFeatures")]
        public GatedAPIFeatures[] GatedAPIFeatures
        {
            get;
            set;
        }
    }
}