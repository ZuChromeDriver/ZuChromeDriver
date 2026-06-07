namespace Zu.ChromeDevTools.Performance
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets time domain to use for collecting and reporting duration metrics.
    /// Note that this must be called before enabling metrics collection. Calling
    /// this method while metrics collection is enabled returns an error.
    /// </summary>
    public sealed class SetTimeDomainCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Performance.setTimeDomain";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Time domain
        /// </summary>
        [JsonPropertyName("timeDomain")]
        public string TimeDomain
        {
            get;
            set;
        }
    }

    public sealed class SetTimeDomainCommandResponse : ICommandResponse<SetTimeDomainCommand>
    {
    }
}