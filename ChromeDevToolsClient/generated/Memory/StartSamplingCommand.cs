namespace Zu.ChromeDevTools.Memory
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Start collecting native memory profile.
    /// </summary>
    public sealed class StartSamplingCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Memory.startSampling";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Average number of bytes between samples.
        /// </summary>
        [JsonPropertyName("samplingInterval")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? SamplingInterval
        {
            get;
            set;
        }
        /// <summary>
        /// Do not randomize intervals between samples.
        /// </summary>
        [JsonPropertyName("suppressRandomness")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? SuppressRandomness
        {
            get;
            set;
        }
    }

    public sealed class StartSamplingCommandResponse : ICommandResponse<StartSamplingCommand>
    {
    }
}