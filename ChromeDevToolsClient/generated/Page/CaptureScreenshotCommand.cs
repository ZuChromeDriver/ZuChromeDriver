namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Capture page screenshot.
    /// </summary>
    public sealed class CaptureScreenshotCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.captureScreenshot";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Image compression format (defaults to png).
        /// </summary>
        [JsonPropertyName("format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Format
        {
            get;
            set;
        }
        /// <summary>
        /// Compression quality from range [0..100] (jpeg only).
        /// </summary>
        [JsonPropertyName("quality")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Quality
        {
            get;
            set;
        }
        /// <summary>
        /// Capture the screenshot of a given region only.
        /// </summary>
        [JsonPropertyName("clip")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Viewport Clip
        {
            get;
            set;
        }
        /// <summary>
        /// Capture the screenshot from the surface, rather than the view. Defaults to true.
        /// </summary>
        [JsonPropertyName("fromSurface")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? FromSurface
        {
            get;
            set;
        }
        /// <summary>
        /// Capture the screenshot beyond the viewport. Defaults to false.
        /// </summary>
        [JsonPropertyName("captureBeyondViewport")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? CaptureBeyondViewport
        {
            get;
            set;
        }
        /// <summary>
        /// Optimize image encoding for speed, not for resulting size (defaults to false)
        /// </summary>
        [JsonPropertyName("optimizeForSpeed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? OptimizeForSpeed
        {
            get;
            set;
        }
    }

    public sealed class CaptureScreenshotCommandResponse : ICommandResponse<CaptureScreenshotCommand>
    {
        /// <summary>
        /// Base64-encoded image data. (Encoded as a base64 string when passed over JSON)
        ///</summary>
        [JsonPropertyName("data")]
        public string Data
        {
            get;
            set;
        }
    }
}