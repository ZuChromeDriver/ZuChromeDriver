namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Fired whenever a stylesheet is changed as a result of the client operation.
    /// </summary>
    public sealed class StyleSheetChangedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the styleSheetId
        /// </summary>
        [JsonPropertyName("styleSheetId")]
        public string StyleSheetId
        {
            get;
            set;
        }
    }
}