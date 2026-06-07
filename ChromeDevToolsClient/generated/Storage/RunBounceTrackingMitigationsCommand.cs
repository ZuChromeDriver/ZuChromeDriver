namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Deletes state for sites identified as potential bounce trackers, immediately.
    /// </summary>
    public sealed class RunBounceTrackingMitigationsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.runBounceTrackingMitigations";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class RunBounceTrackingMitigationsCommandResponse : ICommandResponse<RunBounceTrackingMitigationsCommand>
    {
        /// <summary>
        /// Gets or sets the deletedSites
        /// </summary>
        [JsonPropertyName("deletedSites")]
        public string[] DeletedSites
        {
            get;
            set;
        }
    }
}