namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Set dock tile details, platform-specific.
    /// </summary>
    public sealed class SetDockTileCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Browser.setDockTile";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the badgeLabel
        /// </summary>
        [JsonPropertyName("badgeLabel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BadgeLabel
        {
            get;
            set;
        }
        /// <summary>
        /// Png encoded image. (Encoded as a base64 string when passed over JSON)
        /// </summary>
        [JsonPropertyName("image")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Image
        {
            get;
            set;
        }
    }

    public sealed class SetDockTileCommandResponse : ICommandResponse<SetDockTileCommand>
    {
    }
}