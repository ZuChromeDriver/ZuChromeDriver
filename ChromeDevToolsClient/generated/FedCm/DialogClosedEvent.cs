namespace Zu.ChromeDevTools.FedCm
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Triggered when a dialog is closed, either by user action, JS abort,
    /// or a command below.
    /// </summary>
    public sealed class DialogClosedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the dialogId
        /// </summary>
        [JsonPropertyName("dialogId")]
        public string DialogId
        {
            get;
            set;
        }
    }
}