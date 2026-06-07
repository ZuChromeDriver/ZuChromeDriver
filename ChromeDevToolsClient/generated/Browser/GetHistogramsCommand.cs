namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Get Chrome histograms.
    /// </summary>
    public sealed class GetHistogramsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Browser.getHistograms";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Requested substring in name. Only histograms which have query as a
        /// substring in their name are extracted. An empty or absent query returns
        /// all histograms.
        /// </summary>
        [JsonPropertyName("query")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Query
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

    public sealed class GetHistogramsCommandResponse : ICommandResponse<GetHistogramsCommand>
    {
        /// <summary>
        /// Histograms.
        ///</summary>
        [JsonPropertyName("histograms")]
        public Histogram[] Histograms
        {
            get;
            set;
        }
    }
}