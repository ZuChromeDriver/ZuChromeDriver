namespace Zu.ChromeDevTools.BluetoothEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Stores the manufacturer data
    /// </summary>
    public sealed class ManufacturerData
    {
        /// <summary>
        /// Company identifier
        /// https://bitbucket.org/bluetooth-SIG/public/src/main/assigned_numbers/company_identifiers/company_identifiers.yaml
        /// https://usb.org/developers
        ///</summary>
        [JsonPropertyName("key")]
        public long Key
        {
            get;
            set;
        }
        /// <summary>
        /// Manufacturer-specific data (Encoded as a base64 string when passed over JSON)
        ///</summary>
        [JsonPropertyName("data")]
        public string Data
        {
            get;
            set;
        }
    }
}