namespace Zu.ChromeDevTools.SmartCardEmulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Maps to the |SCARD_STATE_*| flags.
    /// </summary>
    public sealed class ReaderStateFlags
    {
        /// <summary>
        /// Gets or sets the unaware
        /// </summary>
        [JsonPropertyName("unaware")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Unaware
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the ignore
        /// </summary>
        [JsonPropertyName("ignore")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Ignore
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the changed
        /// </summary>
        [JsonPropertyName("changed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Changed
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the unknown
        /// </summary>
        [JsonPropertyName("unknown")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Unknown
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the unavailable
        /// </summary>
        [JsonPropertyName("unavailable")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Unavailable
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the empty
        /// </summary>
        [JsonPropertyName("empty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Empty
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the present
        /// </summary>
        [JsonPropertyName("present")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Present
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the exclusive
        /// </summary>
        [JsonPropertyName("exclusive")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Exclusive
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the inuse
        /// </summary>
        [JsonPropertyName("inuse")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Inuse
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the mute
        /// </summary>
        [JsonPropertyName("mute")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Mute
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the unpowered
        /// </summary>
        [JsonPropertyName("unpowered")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Unpowered
        {
            get;
            set;
        }
    }
}