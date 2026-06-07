namespace Zu.ChromeDevTools.FedCm
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Resets the cooldown time, if any, to allow the next FedCM call to show
    /// a dialog even if one was recently dismissed by the user.
    /// </summary>
    public sealed class ResetCooldownCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "FedCm.resetCooldown";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class ResetCooldownCommandResponse : ICommandResponse<ResetCooldownCommand>
    {
    }
}