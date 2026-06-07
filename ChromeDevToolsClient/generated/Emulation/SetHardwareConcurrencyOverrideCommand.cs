namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SetHardwareConcurrencyOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setHardwareConcurrencyOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Hardware concurrency to report
        /// </summary>
        [JsonPropertyName("hardwareConcurrency")]
        public long HardwareConcurrency
        {
            get;
            set;
        }
    }

    public sealed class SetHardwareConcurrencyOverrideCommandResponse : ICommandResponse<SetHardwareConcurrencyOverrideCommand>
    {
    }
}