namespace Zu.ChromeDevTools.Profiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Profile node. Holds callsite information, execution statistics and child nodes.
    /// </summary>
    public sealed class ProfileNode
    {
        /// <summary>
        /// Unique id of the node.
        ///</summary>
        [JsonPropertyName("id")]
        public long Id
        {
            get;
            set;
        }
        /// <summary>
        /// Function location.
        ///</summary>
        [JsonPropertyName("callFrame")]
        public Runtime.CallFrame CallFrame
        {
            get;
            set;
        }
        /// <summary>
        /// Number of samples where this node was on top of the call stack.
        ///</summary>
        [JsonPropertyName("hitCount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? HitCount
        {
            get;
            set;
        }
        /// <summary>
        /// Child node ids.
        ///</summary>
        [JsonPropertyName("children")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long[] Children
        {
            get;
            set;
        }
        /// <summary>
        /// The reason of being not optimized. The function may be deoptimized or marked as don't
        /// optimize.
        ///</summary>
        [JsonPropertyName("deoptReason")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string DeoptReason
        {
            get;
            set;
        }
        /// <summary>
        /// An array of source position ticks.
        ///</summary>
        [JsonPropertyName("positionTicks")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public PositionTickInfo[] PositionTicks
        {
            get;
            set;
        }
    }
}