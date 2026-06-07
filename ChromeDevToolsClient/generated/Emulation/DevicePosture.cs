namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DevicePosture
    {
        /// <summary>
        /// Current posture of the device
        ///</summary>
        [JsonPropertyName("type")]
        public string Type
        {
            get;
            set;
        }
    }
}