namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Retrieves a list of available targets.
    /// </summary>
    public sealed class GetTargetsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Target.getTargets";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Only targets matching filter will be reported. If filter is not specified
        /// and target discovery is currently enabled, a filter used for target discovery
        /// is used for consistency.
        /// </summary>
        [JsonPropertyName("filter")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public FilterEntry[] Filter
        {
            get;
            set;
        }
    }

    public sealed class GetTargetsCommandResponse : ICommandResponse<GetTargetsCommand>
    {
        /// <summary>
        /// The list of targets.
        ///</summary>
        [JsonPropertyName("targetInfos")]
        public TargetInfo[] TargetInfos
        {
            get;
            set;
        }
    }
}