namespace Zu.ChromeDevTools.Target
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns information about a target.
    /// </summary>
    public sealed class GetTargetInfoCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Target.getTargetInfo";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the targetId
        /// </summary>
        [JsonPropertyName("targetId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TargetId
        {
            get;
            set;
        }
    }

    public sealed class GetTargetInfoCommandResponse : ICommandResponse<GetTargetInfoCommand>
    {
        /// <summary>
        /// Gets or sets the targetInfo
        /// </summary>
        [JsonPropertyName("targetInfo")]
        public TargetInfo TargetInfo
        {
            get;
            set;
        }
    }
}