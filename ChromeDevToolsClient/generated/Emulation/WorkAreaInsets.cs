namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class WorkAreaInsets
    {
        /// <summary>
        /// Work area top inset in pixels. Default is 0;
        ///</summary>
        [JsonPropertyName("top")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Top
        {
            get;
            set;
        }
        /// <summary>
        /// Work area left inset in pixels. Default is 0;
        ///</summary>
        [JsonPropertyName("left")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Left
        {
            get;
            set;
        }
        /// <summary>
        /// Work area bottom inset in pixels. Default is 0;
        ///</summary>
        [JsonPropertyName("bottom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Bottom
        {
            get;
            set;
        }
        /// <summary>
        /// Work area right inset in pixels. Default is 0;
        ///</summary>
        [JsonPropertyName("right")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Right
        {
            get;
            set;
        }
    }
}