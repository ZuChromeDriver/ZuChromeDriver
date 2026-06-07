namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Override the value of navigator.connection.saveData
    /// </summary>
    public sealed class SetDataSaverOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setDataSaverOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Override value. Omitting the parameter disables the override.
        /// </summary>
        [JsonPropertyName("dataSaverEnabled")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? DataSaverEnabled
        {
            get;
            set;
        }
    }

    public sealed class SetDataSaverOverrideCommandResponse : ICommandResponse<SetDataSaverOverrideCommand>
    {
    }
}