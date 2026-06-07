namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fires whenever a web font is updated.  A non-empty font parameter indicates a successfully loaded
    /// web font.
    /// </summary>
    public sealed class FontsUpdatedEvent : IEvent
    {
        /// <summary>
        /// The web font that has loaded.
        /// </summary>
        [JsonPropertyName("font")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FontFace Font
        {
            get;
            set;
        }
    }
}