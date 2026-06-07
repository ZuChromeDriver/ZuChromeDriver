namespace Zu.ChromeDevTools.Browser
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Grant specific permissions to the given origin and reject all others. Deprecated. Use
    /// setPermission instead.
    /// </summary>
    public sealed class GrantPermissionsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Browser.grantPermissions";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the permissions
        /// </summary>
        [JsonPropertyName("permissions")]
        public PermissionType[] Permissions
        {
            get;
            set;
        }
        /// <summary>
        /// Origin the permission applies to, all origins if not specified.
        /// </summary>
        [JsonPropertyName("origin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Origin
        {
            get;
            set;
        }
        /// <summary>
        /// BrowserContext to override permissions. When omitted, default browser context is used.
        /// </summary>
        [JsonPropertyName("browserContextId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string BrowserContextId
        {
            get;
            set;
        }
    }

    public sealed class GrantPermissionsCommandResponse : ICommandResponse<GrantPermissionsCommand>
    {
    }
}