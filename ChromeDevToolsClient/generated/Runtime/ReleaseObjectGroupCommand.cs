namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Releases all remote objects that belong to a given group.
    /// </summary>
    public sealed class ReleaseObjectGroupCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Runtime.releaseObjectGroup";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Symbolic object group name.
        /// </summary>
        [JsonPropertyName("objectGroup")]
        public string ObjectGroup
        {
            get;
            set;
        }
    }

    public sealed class ReleaseObjectGroupCommandResponse : ICommandResponse<ReleaseObjectGroupCommand>
    {
    }
}