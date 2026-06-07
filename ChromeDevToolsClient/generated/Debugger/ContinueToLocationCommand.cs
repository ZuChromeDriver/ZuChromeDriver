namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Continues execution until specific location is reached.
    /// </summary>
    public sealed class ContinueToLocationCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.continueToLocation";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Location to continue to.
        /// </summary>
        [JsonPropertyName("location")]
        public Location Location
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the targetCallFrames
        /// </summary>
        [JsonPropertyName("targetCallFrames")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TargetCallFrames
        {
            get;
            set;
        }
    }

    public sealed class ContinueToLocationCommandResponse : ICommandResponse<ContinueToLocationCommand>
    {
    }
}