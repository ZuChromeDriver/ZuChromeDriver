namespace Zu.ChromeDevTools.Storage
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Gets details for a named interest group.
    /// </summary>
    public sealed class GetInterestGroupDetailsCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Storage.getInterestGroupDetails";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the ownerOrigin
        /// </summary>
        [JsonPropertyName("ownerOrigin")]
        public string OwnerOrigin
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
    }

    public sealed class GetInterestGroupDetailsCommandResponse : ICommandResponse<GetInterestGroupDetailsCommand>
    {
        /// <summary>
        /// This largely corresponds to:
        /// https://wicg.github.io/turtledove/#dictdef-generatebidinterestgroup
        /// but has absolute expirationTime instead of relative lifetimeMs and
        /// also adds joiningOrigin.
        ///</summary>
        [JsonPropertyName("details")]
        public object Details
        {
            get;
            set;
        }
    }
}