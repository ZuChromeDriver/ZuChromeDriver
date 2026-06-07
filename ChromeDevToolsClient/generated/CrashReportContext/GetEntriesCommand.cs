namespace Zu.ChromeDevTools.CrashReportContext
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns all entries in the CrashReportContext across all frames in the page.
    /// </summary>
    public sealed class GetEntriesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CrashReportContext.getEntries";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetEntriesCommandResponse : ICommandResponse<GetEntriesCommand>
    {
        /// <summary>
        /// Gets or sets the entries
        /// </summary>
        [JsonPropertyName("entries")]
        public CrashReportContextEntry[] Entries
        {
            get;
            set;
        }
    }
}