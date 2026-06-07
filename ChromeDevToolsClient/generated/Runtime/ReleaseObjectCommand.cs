namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Releases remote object with given id.
    /// </summary>
    public sealed class ReleaseObjectCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Runtime.releaseObject";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the object to release.
        /// </summary>
        [JsonPropertyName("objectId")]
        public string ObjectId
        {
            get;
            set;
        }
    }

    public sealed class ReleaseObjectCommandResponse : ICommandResponse<ReleaseObjectCommand>
    {
    }
}