namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clears the overridden device metrics.
    /// </summary>
    public sealed class ClearDeviceMetricsOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.clearDeviceMetricsOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class ClearDeviceMetricsOverrideCommandResponse : ICommandResponse<ClearDeviceMetricsOverrideCommand>
    {
    }
}