namespace Zu.ChromeDevTools.HeadlessExperimental
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Enables headless events for the target.
    /// </summary>
    public sealed class EnableCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "HeadlessExperimental.enable";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class EnableCommandResponse : ICommandResponse<EnableCommand>
    {
    }
}