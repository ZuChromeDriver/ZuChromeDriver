namespace Zu.ChromeDevTools.FedCm
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DismissDialogCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "FedCm.dismissDialog";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the dialogId
        /// </summary>
        [JsonPropertyName("dialogId")]
        public string DialogId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the triggerCooldown
        /// </summary>
        [JsonPropertyName("triggerCooldown")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? TriggerCooldown
        {
            get;
            set;
        }
    }

    public sealed class DismissDialogCommandResponse : ICommandResponse<DismissDialogCommand>
    {
    }
}