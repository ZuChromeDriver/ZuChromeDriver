namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired when frame has been attached to its parent.
    /// </summary>
    public sealed class FrameAttachedEvent : IEvent
    {
        /// <summary>
        /// Id of the frame that has been attached.
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Parent frame identifier.
        /// </summary>
        [JsonPropertyName("parentFrameId")]
        public string ParentFrameId
        {
            get;
            set;
        }
        /// <summary>
        /// JavaScript stack trace of when frame was attached, only set if frame initiated from script.
        /// </summary>
        [JsonPropertyName("stack")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Runtime.StackTrace Stack
        {
            get;
            set;
        }
    }
}