namespace Zu.ChromeDevTools.Tracing
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Return a descriptor for all available tracing categories.
    /// </summary>
    public sealed class GetTrackEventDescriptorCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Tracing.getTrackEventDescriptor";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

    }

    public sealed class GetTrackEventDescriptorCommandResponse : ICommandResponse<GetTrackEventDescriptorCommand>
    {
        /// <summary>
        /// Base64-encoded serialized perfetto.protos.TrackEventDescriptor protobuf message. (Encoded as a base64 string when passed over JSON)
        ///</summary>
        [JsonPropertyName("descriptor")]
        public string Descriptor
        {
            get;
            set;
        }
    }
}