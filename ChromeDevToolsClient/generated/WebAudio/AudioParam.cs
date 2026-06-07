namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Protocol object for AudioParam
    /// </summary>
    public sealed class AudioParam
    {
        /// <summary>
        /// Gets or sets the paramId
        /// </summary>
        [JsonPropertyName("paramId")]
        public string ParamId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the nodeId
        /// </summary>
        [JsonPropertyName("nodeId")]
        public string NodeId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the contextId
        /// </summary>
        [JsonPropertyName("contextId")]
        public string ContextId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the paramType
        /// </summary>
        [JsonPropertyName("paramType")]
        public string ParamType
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the rate
        /// </summary>
        [JsonPropertyName("rate")]
        public AutomationRate Rate
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the defaultValue
        /// </summary>
        [JsonPropertyName("defaultValue")]
        public double DefaultValue
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the minValue
        /// </summary>
        [JsonPropertyName("minValue")]
        public double MinValue
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the maxValue
        /// </summary>
        [JsonPropertyName("maxValue")]
        public double MaxValue
        {
            get;
            set;
        }
    }
}