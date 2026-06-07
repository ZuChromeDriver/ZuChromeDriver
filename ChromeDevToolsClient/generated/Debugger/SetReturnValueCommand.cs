namespace Zu.ChromeDevTools.Debugger
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Changes return value in top frame. Available only at return break position.
    /// </summary>
    public sealed class SetReturnValueCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Debugger.setReturnValue";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// New return value.
        /// </summary>
        [JsonPropertyName("newValue")]
        public Runtime.CallArgument NewValue
        {
            get;
            set;
        }
    }

    public sealed class SetReturnValueCommandResponse : ICommandResponse<SetReturnValueCommand>
    {
    }
}