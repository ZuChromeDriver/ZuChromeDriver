namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Sets or clears an override of the default background color of the frame. This override is used
    /// if the content does not specify one.
    /// </summary>
    public sealed class SetDefaultBackgroundColorOverrideCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setDefaultBackgroundColorOverride";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// RGBA of the default background color. If not specified, any existing override will be
        /// cleared.
        /// </summary>
        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DOM.RGBA Color
        {
            get;
            set;
        }
    }

    public sealed class SetDefaultBackgroundColorOverrideCommandResponse : ICommandResponse<SetDefaultBackgroundColorOverrideCommand>
    {
    }
}