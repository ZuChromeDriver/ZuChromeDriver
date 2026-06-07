namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns all class names from specified stylesheet.
    /// </summary>
    public sealed class CollectClassNamesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.collectClassNames";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the styleSheetId
        /// </summary>
        [JsonPropertyName("styleSheetId")]
        public string StyleSheetId
        {
            get;
            set;
        }
    }

    public sealed class CollectClassNamesCommandResponse : ICommandResponse<CollectClassNamesCommand>
    {
        /// <summary>
        /// Class name list.
        ///</summary>
        [JsonPropertyName("classNames")]
        public string[] ClassNames
        {
            get;
            set;
        }
    }
}