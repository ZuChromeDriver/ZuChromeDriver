namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SetDisabledImageTypesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.setDisabledImageTypes";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Image types to disable.
        /// </summary>
        [JsonPropertyName("imageTypes")]
        public DisabledImageType[] ImageTypes
        {
            get;
            set;
        }
    }

    public sealed class SetDisabledImageTypesCommandResponse : ICommandResponse<SetDisabledImageTypesCommand>
    {
    }
}