namespace Zu.ChromeDevTools.Performance
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enable collecting and reporting metrics.
    /// </summary>
    public sealed class EnableCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Performance.enable";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Time domain to use for collecting and reporting duration metrics.
        /// </summary>
        [JsonPropertyName("timeDomain")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TimeDomain
        {
            get;
            set;
        }
    }

    public sealed class EnableCommandResponse : ICommandResponse<EnableCommand>
    {
    }
}