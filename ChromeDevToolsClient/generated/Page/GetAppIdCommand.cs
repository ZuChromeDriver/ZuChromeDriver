namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the unique (PWA) app id.
    /// Only returns values if the feature flag 'WebAppEnableManifestId' is enabled
    /// </summary>
    public sealed class GetAppIdCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.getAppId";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetAppIdCommandResponse : ICommandResponse<GetAppIdCommand>
    {
        /// <summary>
        /// App id, either from manifest's id attribute or computed from start_url
        ///</summary>
        [JsonPropertyName("appId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string AppId
        {
            get;
            set;
        }
        /// <summary>
        /// Recommendation for manifest's id attribute to match current id computed from start_url
        ///</summary>
        [JsonPropertyName("recommendedId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string RecommendedId
        {
            get;
            set;
        }
    }
}