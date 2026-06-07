namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Get a Chrome histogram by name.
    /// </summary>
    public sealed class GetHistogramCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Browser.getHistogram";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Requested histogram name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// If true, retrieve delta since last delta call.
        /// </summary>
        [JsonPropertyName("delta")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Delta
        {
            get;
            set;
        }
    }

    public sealed class GetHistogramCommandResponse : ICommandResponse<GetHistogramCommand>
    {
        /// <summary>
        /// Histogram.
        ///</summary>
        [JsonPropertyName("histogram")]
        public Histogram Histogram
        {
            get;
            set;
        }
    }
}