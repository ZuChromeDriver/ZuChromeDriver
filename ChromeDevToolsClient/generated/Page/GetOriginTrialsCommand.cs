namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Get Origin Trials on given frame.
    /// </summary>
    public sealed class GetOriginTrialsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.getOriginTrials";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the frameId
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
    }

    public sealed class GetOriginTrialsCommandResponse : ICommandResponse<GetOriginTrialsCommand>
    {
        /// <summary>
        /// Gets or sets the originTrials
        /// </summary>
        [JsonPropertyName("originTrials")]
        public OriginTrial[] OriginTrials
        {
            get;
            set;
        }
    }
}