namespace Zu.ChromeDevTools.DeviceAccess
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A device request opened a user prompt to select a device. Respond with the
    /// selectPrompt or cancelPrompt command.
    /// </summary>
    public sealed class DeviceRequestPromptedEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the devices
        /// </summary>
        [JsonPropertyName("devices")]
        public PromptDevice[] Devices
        {
            get;
            set;
        }
    }
}