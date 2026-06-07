namespace Zu.ChromeDevTools.PWA
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The following types are the replica of
    /// https://crsrc.org/c/chrome/browser/web_applications/proto/web_app_os_integration_state.proto;drc=9910d3be894c8f142c977ba1023f30a656bc13fc;l=67
    /// </summary>
    public sealed class FileHandlerAccept
    {
        /// <summary>
        /// New name of the mimetype according to
        /// https://www.iana.org/assignments/media-types/media-types.xhtml
        ///</summary>
        [JsonPropertyName("mediaType")]
        public string MediaType
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the fileExtensions
        /// </summary>
        [JsonPropertyName("fileExtensions")]
        public string[] FileExtensions
        {
            get;
            set;
        }
    }
}