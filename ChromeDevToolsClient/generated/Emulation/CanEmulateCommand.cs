namespace Zu.ChromeDevTools.Emulation
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Tells whether emulation is supported.
    /// </summary>
    public sealed class CanEmulateCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Emulation.canEmulate";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class CanEmulateCommandResponse : ICommandResponse<CanEmulateCommand>
    {
        /// <summary>
        /// True if emulation is supported.
        ///</summary>
        [JsonPropertyName("result")]
        public bool Result
        {
            get;
            set;
        }
    }
}