namespace Zu.ChromeDevTools.FedCm
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ClickDialogButtonCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "FedCm.clickDialogButton";
        
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
        /// Gets or sets the dialogButton
        /// </summary>
        [JsonPropertyName("dialogButton")]
        public DialogButton DialogButton
        {
            get;
            set;
        }
    }

    public sealed class ClickDialogButtonCommandResponse : ICommandResponse<ClickDialogButtonCommand>
    {
    }
}