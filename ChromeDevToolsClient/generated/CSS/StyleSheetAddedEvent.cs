namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired whenever an active document stylesheet is added.
    /// </summary>
    public sealed class StyleSheetAddedEvent : IEvent
    {
        /// <summary>
        /// Added stylesheet metainfo.
        /// </summary>
        [JsonPropertyName("header")]
        public CSSStyleSheetHeader Header
        {
            get;
            set;
        }
    }
}