namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Maps to the |SCARD_PROTOCOL_*| flags.
    /// </summary>
    public sealed class ProtocolSet
    {
        /// <summary>
        /// Gets or sets the t0
        /// </summary>
        [JsonPropertyName("t0")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? T0
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the t1
        /// </summary>
        [JsonPropertyName("t1")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? T1
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the raw
        /// </summary>
        [JsonPropertyName("raw")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Raw
        {
            get;
            set;
        }
    }
}