namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Information about the Frame hierarchy along with their cached resources.
    /// </summary>
    public sealed class FrameResourceTree
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
        public FrameResourceTree[] ChildFrames
        {
            get;
            set;
        }
        /// <summary>
        /// Information about frame resources.
        ///</summary>
        [JsonPropertyName("resources")]
        public FrameResource[] Resources
        {
            get;
            set;
        }
    }
}