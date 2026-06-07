namespace Zu.ChromeDevTools.Autofill
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Set addresses so that developers can verify their forms implementation.
    /// </summary>
    public sealed class SetAddressesCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Autofill.setAddresses";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Gets or sets the addresses
        /// </summary>
        [JsonPropertyName("addresses")]
        public Address[] Addresses
        {
            get;
            set;
        }
    }

    public sealed class SetAddressesCommandResponse : ICommandResponse<SetAddressesCommand>
    {
    }
}