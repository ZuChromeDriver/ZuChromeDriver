namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Polls the next batch of computed style updates.
    /// </summary>
    public sealed class TakeComputedStyleUpdatesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.takeComputedStyleUpdates";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class TakeComputedStyleUpdatesCommandResponse : ICommandResponse<TakeComputedStyleUpdatesCommand>
    {
        /// <summary>
        /// The list of node Ids that have their tracked computed styles updated.
        ///</summary>
        [JsonPropertyName("nodeIds")]
        public long[] NodeIds
        {
            get;
            set;
        }
    }
}