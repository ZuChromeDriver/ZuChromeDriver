namespace Zu.ChromeDevTools.Animation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Timeline instance
    /// </summary>
    public sealed class ViewOrScrollTimeline
    {
        /// <summary>
        /// Scroll container node
        ///</summary>
        [JsonPropertyName("sourceNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? SourceNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Represents the starting scroll position of the timeline
        /// as a length offset in pixels from scroll origin.
        ///</summary>
        [JsonPropertyName("startOffset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? StartOffset
        {
            get;
            set;
        }
        /// <summary>
        /// Represents the ending scroll position of the timeline
        /// as a length offset in pixels from scroll origin.
        ///</summary>
        [JsonPropertyName("endOffset")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? EndOffset
        {
            get;
            set;
        }
        /// <summary>
        /// The element whose principal box's visibility in the
        /// scrollport defined the progress of the timeline.
        /// Does not exist for animations with ScrollTimeline
        ///</summary>
        [JsonPropertyName("subjectNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? SubjectNodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Orientation of the scroll
        ///</summary>
        [JsonPropertyName("axis")]
        public DOM.ScrollOrientation Axis
        {
            get;
            set;
        }
    }
}