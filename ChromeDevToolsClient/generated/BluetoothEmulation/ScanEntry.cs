namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Stores the advertisement packet information that is sent by a Bluetooth device.
    /// </summary>
    public sealed class ScanEntry
    {
        /// <summary>
        /// Gets or sets the deviceAddress
        /// </summary>
        [JsonPropertyName("deviceAddress")]
        public string DeviceAddress
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the rssi
        /// </summary>
        [JsonPropertyName("rssi")]
        public long Rssi
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the scanRecord
        /// </summary>
        [JsonPropertyName("scanRecord")]
        public ScanRecord ScanRecord
        {
            get;
            set;
        }
    }
}