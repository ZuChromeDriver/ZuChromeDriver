namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class QueryObjectsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Runtime.queryObjects";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifier of the prototype to return objects for.
        /// </summary>
        [JsonPropertyName("prototypeObjectId")]
        public string PrototypeObjectId
        {
            get;
            set;
        }
        /// <summary>
        /// Symbolic group name that can be used to release the results.
        /// </summary>
        [JsonPropertyName("objectGroup")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectGroup
        {
            get;
            set;
        }
    }

    public sealed class QueryObjectsCommandResponse : ICommandResponse<QueryObjectsCommand>
    {
        /// <summary>
        /// Array with objects.
        ///</summary>
        [JsonPropertyName("objects")]
        public RemoteObject Objects
        {
            get;
            set;
        }
    }
}