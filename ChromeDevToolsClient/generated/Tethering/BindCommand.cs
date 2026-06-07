namespace Zu.ChromeDevTools.Tethering
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Request browser port binding.
    /// </summary>
    public sealed class BindCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Tethering.bind";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Port number to bind.
        /// </summary>
        [JsonPropertyName("port")]
        public long Port
        {
            get;
            set;
        }
    }

    public sealed class BindCommandResponse : ICommandResponse<BindCommand>
    {
    }
}