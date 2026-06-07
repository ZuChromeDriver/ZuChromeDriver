namespace Zu.ChromeDevTools.DeviceAccess
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Device information displayed in a user prompt to select a device.
    /// </summary>
    public sealed class PromptDevice
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
        /// Display name as it appears in a device request user prompt.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
    }
}