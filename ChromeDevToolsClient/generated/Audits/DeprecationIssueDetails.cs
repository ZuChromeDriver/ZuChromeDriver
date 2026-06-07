namespace Zu.ChromeDevTools.Audits
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// This issue tracks information needed to print a deprecation message.
    /// https://source.chromium.org/chromium/chromium/src/+/main:third_party/blink/renderer/core/frame/third_party/blink/renderer/core/frame/deprecation/README.md
    /// </summary>
    public sealed class DeprecationIssueDetails
    {
        /// <summary>
        /// Gets or sets the affectedFrame
        /// </summary>
        [JsonPropertyName("affectedFrame")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public AffectedFrame AffectedFrame
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the sourceCodeLocation
        /// </summary>
        [JsonPropertyName("sourceCodeLocation")]
        public SourceCodeLocation SourceCodeLocation
        {
            get;
            set;
        }
        /// <summary>
        /// One of the deprecation names from third_party/blink/renderer/core/frame/deprecation/deprecation.json5
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
    }
}