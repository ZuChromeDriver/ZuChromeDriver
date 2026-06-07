namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Set permission settings for given embedding and embedded origins.
    /// </summary>
    public sealed class SetPermissionCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Browser.setPermission";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Descriptor of permission to override.
        /// </summary>
        [JsonPropertyName("permission")]
        public PermissionDescriptor Permission
        {
            get;
            set;
        }
        /// <summary>
        /// Setting of the permission.
        /// </summary>
        [JsonPropertyName("setting")]
        public PermissionSetting Setting
        {
            get;
            set;
        }
        /// <summary>
        /// Embedding origin the permission applies to, all origins if not specified.
        /// </summary>
        [JsonPropertyName("origin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Origin
        {
            get;
            set;
        }
        /// <summary>
        /// Embedded origin the permission applies to. It is ignored unless the embedding origin is
        /// present and valid. If the embedding origin is provided but the embedded origin isn't, the
        /// embedding origin is used as the embedded origin.
        /// </summary>
        [JsonPropertyName("embeddedOrigin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string EmbeddedOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Context to override. When omitted, default browser context is used.
        /// </summary>
        [JsonPropertyName("browserContextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BrowserContextId
        {
            get;
            set;
        }
    }

    public sealed class SetPermissionCommandResponse : ICommandResponse<SetPermissionCommand>
    {
    }
}