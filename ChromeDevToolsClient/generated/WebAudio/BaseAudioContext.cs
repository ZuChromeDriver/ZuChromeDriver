namespace Zu.ChromeDevTools.WebAudio
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Protocol object for BaseAudioContext
    /// </summary>
    public sealed class BaseAudioContext
    {
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
        /// Gets or sets the contextType
        /// </summary>
        [JsonPropertyName("contextType")]
        public ContextType ContextType
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the contextState
        /// </summary>
        [JsonPropertyName("contextState")]
        public ContextState ContextState
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the realtimeData
        /// </summary>
        [JsonPropertyName("realtimeData")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public ContextRealtimeData RealtimeData
        {
            get;
            set;
        }
        /// <summary>
        /// Platform-dependent callback buffer size.
        ///</summary>
        [JsonPropertyName("callbackBufferSize")]
        public double CallbackBufferSize
        {
            get;
            set;
        }
        /// <summary>
        /// Number of output channels supported by audio hardware in use.
        ///</summary>
        [JsonPropertyName("maxOutputChannelCount")]
        public double MaxOutputChannelCount
        {
            get;
            set;
        }
        /// <summary>
        /// Context sample rate.
        ///</summary>
        [JsonPropertyName("sampleRate")]
        public double SampleRate
        {
            get;
            set;
        }
    }
}