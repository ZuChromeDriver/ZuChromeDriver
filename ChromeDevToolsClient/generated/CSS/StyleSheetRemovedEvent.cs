namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired whenever an active document stylesheet is removed.
    /// </summary>
    public sealed class StyleSheetRemovedEvent : IEvent
    {
        /// <summary>
        /// Identifier of the removed stylesheet.
        /// </summary>
        [JsonPropertyName("styleSheetId")]
        public string StyleSheetId
        {
            get;
            set;
        }
    }
}