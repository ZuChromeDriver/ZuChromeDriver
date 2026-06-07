namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Returns the isolate id.
    /// </summary>
    public sealed class GetIsolateIdCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Runtime.getIsolateId";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetIsolateIdCommandResponse : ICommandResponse<GetIsolateIdCommand>
    {
        /// <summary>
        /// The isolate id.
        ///</summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
    }
}