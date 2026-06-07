namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about the Frame hierarchy.
    /// </summary>
    public sealed class FrameTree
    {
        /// <summary>
        /// Frame information for this tree item.
        ///</summary>
        [JsonPropertyName("frame")]
        public Frame Frame
        {
            get;
            set;
        }
        /// <summary>
        /// Child frames.
        ///</summary>
        [JsonPropertyName("childFrames")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FrameTree[] ChildFrames
        {
            get;
            set;
        }
    }
}