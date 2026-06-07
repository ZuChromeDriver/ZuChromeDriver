namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Get Permissions Policy state on given frame.
    /// </summary>
    public sealed class GetPermissionsPolicyStateCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Page.getPermissionsPolicyState";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the frameId
        /// </summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
    }

    public sealed class GetPermissionsPolicyStateCommandResponse : ICommandResponse<GetPermissionsPolicyStateCommand>
    {
        /// <summary>
        /// Gets or sets the states
        /// </summary>
        [JsonPropertyName("states")]
        public PermissionsPolicyFeatureState[] States
        {
            get;
            set;
        }
    }
}