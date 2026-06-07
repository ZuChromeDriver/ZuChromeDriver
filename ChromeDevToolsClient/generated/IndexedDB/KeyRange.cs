namespace Zu.ChromeDevTools.IndexedDB
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Key range.
    /// </summary>
    public sealed class KeyRange
    {
        /// <summary>
        /// Lower bound.
        ///</summary>
        [JsonPropertyName("lower")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Key Lower
        {
            get;
            set;
        }
        /// <summary>
        /// Upper bound.
        ///</summary>
        [JsonPropertyName("upper")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Key Upper
        {
            get;
            set;
        }
        /// <summary>
        /// If true lower bound is open.
        ///</summary>
        [JsonPropertyName("lowerOpen")]
        public bool LowerOpen
        {
            get;
            set;
        }
        /// <summary>
        /// If true upper bound is open.
        ///</summary>
        [JsonPropertyName("upperOpen")]
        public bool UpperOpen
        {
            get;
            set;
        }
    }
}