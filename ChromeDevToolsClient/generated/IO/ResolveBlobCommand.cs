namespace Zu.ChromeDevTools.IO
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Return UUID of Blob object specified by a remote object id.
    /// </summary>
    public sealed class ResolveBlobCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "IO.resolveBlob";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Object id of a Blob object wrapper.
        /// </summary>
        [JsonPropertyName("objectId")]
        public string ObjectId
        {
            get;
            set;
        }
    }

    public sealed class ResolveBlobCommandResponse : ICommandResponse<ResolveBlobCommand>
    {
        /// <summary>
        /// UUID of the specified Blob.
        ///</summary>
        [JsonPropertyName("uuid")]
        public string Uuid
        {
            get;
            set;
        }
    }
}