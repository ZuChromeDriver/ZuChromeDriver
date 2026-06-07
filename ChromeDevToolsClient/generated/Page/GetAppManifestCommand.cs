namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Gets the processed manifest for this current document.
    ///   This API always waits for the manifest to be loaded.
    ///   If manifestId is provided, and it does not match the manifest of the
    ///     current document, this API errors out.
    ///   If there is not a loaded page, this API errors out immediately.
    /// </summary>
    public sealed class GetAppManifestCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.getAppManifest";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the manifestId
        /// </summary>
        [JsonPropertyName("manifestId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ManifestId
        {
            get;
            set;
        }
    }

    public sealed class GetAppManifestCommandResponse : ICommandResponse<GetAppManifestCommand>
    {
        /// <summary>
        /// Manifest location.
        ///</summary>
        [JsonPropertyName("url")]
        public string Url
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the errors
        /// </summary>
        [JsonPropertyName("errors")]
        public AppManifestError[] Errors
        {
            get;
            set;
        }
        /// <summary>
        /// Manifest content.
        ///</summary>
        [JsonPropertyName("data")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Data
        {
            get;
            set;
        }
        /// <summary>
        /// Parsed manifest properties. Deprecated, use manifest instead.
        ///</summary>
        [JsonPropertyName("parsed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AppManifestParsedProperties Parsed
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the manifest
        /// </summary>
        [JsonPropertyName("manifest")]
        public WebAppManifest Manifest
        {
            get;
            set;
        }
    }
}