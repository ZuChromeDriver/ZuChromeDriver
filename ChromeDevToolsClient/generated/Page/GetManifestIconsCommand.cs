namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Deprecated because it's not guaranteed that the returned icon is in fact the one used for PWA installation.
    /// </summary>
    public sealed class GetManifestIconsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.getManifestIcons";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetManifestIconsCommandResponse : ICommandResponse<GetManifestIconsCommand>
    {
        /// <summary>
        /// Gets or sets the primaryIcon
        /// </summary>
        [JsonPropertyName("primaryIcon")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string PrimaryIcon
        {
            get;
            set;
        }
    }
}