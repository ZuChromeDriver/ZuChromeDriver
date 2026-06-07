namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SafeAreaInsets
    {
        /// <summary>
        /// Overrides safe-area-inset-top.
        ///</summary>
        [JsonPropertyName("top")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Top
        {
            get;
            set;
        }
        /// <summary>
        /// Overrides safe-area-max-inset-top.
        ///</summary>
        [JsonPropertyName("topMax")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? TopMax
        {
            get;
            set;
        }
        /// <summary>
        /// Overrides safe-area-inset-left.
        ///</summary>
        [JsonPropertyName("left")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Left
        {
            get;
            set;
        }
        /// <summary>
        /// Overrides safe-area-max-inset-left.
        ///</summary>
        [JsonPropertyName("leftMax")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? LeftMax
        {
            get;
            set;
        }
        /// <summary>
        /// Overrides safe-area-inset-bottom.
        ///</summary>
        [JsonPropertyName("bottom")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Bottom
        {
            get;
            set;
        }
        /// <summary>
        /// Overrides safe-area-max-inset-bottom.
        ///</summary>
        [JsonPropertyName("bottomMax")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? BottomMax
        {
            get;
            set;
        }
        /// <summary>
        /// Overrides safe-area-inset-right.
        ///</summary>
        [JsonPropertyName("right")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? Right
        {
            get;
            set;
        }
        /// <summary>
        /// Overrides safe-area-max-inset-right.
        ///</summary>
        [JsonPropertyName("rightMax")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? RightMax
        {
            get;
            set;
        }
    }
}