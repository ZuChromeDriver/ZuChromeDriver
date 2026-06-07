namespace Zu.ChromeDevTools.Tethering
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Request browser port unbinding.
    /// </summary>
    public sealed class UnbindCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Tethering.unbind";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Port number to unbind.
        /// </summary>
        [JsonPropertyName("port")]
        public long Port
        {
            get;
            set;
        }
    }

    public sealed class UnbindCommandResponse : ICommandResponse<UnbindCommand>
    {
    }
}