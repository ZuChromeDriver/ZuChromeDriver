namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Protocol object for AudioNode
    /// </summary>
    public sealed class AudioNode
    {
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
        /// Gets or sets the nodeType
        /// </summary>
        [JsonPropertyName("nodeType")]
        public string NodeType
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the numberOfInputs
        /// </summary>
        [JsonPropertyName("numberOfInputs")]
        public double NumberOfInputs
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the numberOfOutputs
        /// </summary>
        [JsonPropertyName("numberOfOutputs")]
        public double NumberOfOutputs
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the channelCount
        /// </summary>
        [JsonPropertyName("channelCount")]
        public double ChannelCount
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the channelCountMode
        /// </summary>
        [JsonPropertyName("channelCountMode")]
        public ChannelCountMode ChannelCountMode
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the channelInterpretation
        /// </summary>
        [JsonPropertyName("channelInterpretation")]
        public ChannelInterpretation ChannelInterpretation
        {
            get;
            set;
        }
    }
}