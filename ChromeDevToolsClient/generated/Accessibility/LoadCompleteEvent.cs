namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The loadComplete event mirrors the load complete event sent by the browser to assistive
    /// technology when the web page has finished loading.
    /// </summary>
    public sealed class LoadCompleteEvent : IEvent
    {
        /// <summary>
        /// New document root node.
        /// </summary>
        [JsonPropertyName("root")]
        public AXNode Root
        {
            get;
            set;
        }
    }
}