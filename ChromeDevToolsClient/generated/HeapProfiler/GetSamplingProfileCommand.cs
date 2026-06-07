namespace Zu.ChromeDevTools.HeapProfiler
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class GetSamplingProfileCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "HeapProfiler.getSamplingProfile";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetSamplingProfileCommandResponse : ICommandResponse<GetSamplingProfileCommand>
    {
        /// <summary>
        /// Return the sampling profile being collected.
        ///</summary>
        [JsonPropertyName("profile")]
        public SamplingHeapProfile Profile
        {
            get;
            set;
        }
    }
}