namespace Zu.ChromeDevTools.Extensions
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Gets a list of all unpacked extensions.
    /// </summary>
    public sealed class GetExtensionsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Extensions.getExtensions";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetExtensionsCommandResponse : ICommandResponse<GetExtensionsCommand>
    {
        /// <summary>
        /// Gets or sets the extensions
        /// </summary>
        [JsonPropertyName("extensions")]
        public ExtensionInfo[] Extensions
        {
            get;
            set;
        }
    }
}