namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Triggered when the initial set of device bound sessions is added.
    /// </summary>
    public sealed class DeviceBoundSessionsAddedEvent : IEvent
    {
        /// <summary>
        /// The device bound sessions.
        /// </summary>
        [JsonPropertyName("sessions")]
        public DeviceBoundSession[] Sessions
        {
            get;
            set;
        }
    }
}