namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Modifies the expression of a container query.
    /// Deprecated. Use setContainerQueryConditionText instead.
    /// </summary>
    public sealed class SetContainerQueryTextCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "CSS.setContainerQueryText";
        
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
        /// <summary>
        /// Gets or sets the range
        /// </summary>
        [JsonPropertyName("range")]
        public SourceRange Range
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the text
        /// </summary>
        [JsonPropertyName("text")]
        public string Text
        {
            get;
            set;
        }
    }

    public sealed class SetContainerQueryTextCommandResponse : ICommandResponse<SetContainerQueryTextCommand>
    {
        /// <summary>
        /// The resulting CSS container query rule after modification.
        ///</summary>
        [JsonPropertyName("containerQuery")]
        public CSSContainerQuery ContainerQuery
        {
            get;
            set;
        }
    }
}