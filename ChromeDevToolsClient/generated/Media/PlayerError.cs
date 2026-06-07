namespace Zu.ChromeDevTools.Media
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Corresponds to kMediaError
    /// </summary>
    public sealed class PlayerError
    {
        /// <summary>
        /// Gets or sets the errorType
        /// </summary>
        [JsonPropertyName("errorType")]
        public string ErrorType
        {
            get;
            set;
        }
        /// <summary>
        /// Code is the numeric enum entry for a specific set of error codes, such
        /// as PipelineStatusCodes in media/base/pipeline_status.h
        ///</summary>
        [JsonPropertyName("code")]
        public long Code
        {
            get;
            set;
        }
        /// <summary>
        /// A trace of where this error was caused / where it passed through.
        ///</summary>
        [JsonPropertyName("stack")]
        public PlayerErrorSourceLocation[] Stack
        {
            get;
            set;
        }
        /// <summary>
        /// Errors potentially have a root cause error, ie, a DecoderError might be
        /// caused by an WindowsError
        ///</summary>
        [JsonPropertyName("cause")]
        public PlayerError[] Cause
        {
            get;
            set;
        }
        /// <summary>
        /// Extra data attached to an error, such as an HRESULT, Video Codec, etc.
        ///</summary>
        [JsonPropertyName("data")]
        public object Data
        {
            get;
            set;
        }
    }
}