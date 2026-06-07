namespace Zu.ChromeDevTools.Memory
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Executable module information
    /// </summary>
    public sealed class Module
    {
        /// <summary>
        /// Name of the module.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// UUID of the module.
        ///</summary>
        [JsonPropertyName("uuid")]
        public string Uuid
        {
            get;
            set;
        }
        /// <summary>
        /// Base address where the module is loaded into memory. Encoded as a decimal
        /// or hexadecimal (0x prefixed) string.
        ///</summary>
        [JsonPropertyName("baseAddress")]
        public string BaseAddress
        {
            get;
            set;
        }
        /// <summary>
        /// Size of the module in bytes.
        ///</summary>
        [JsonPropertyName("size")]
        public double Size
        {
            get;
            set;
        }
    }
}