namespace Zu.ChromeDevTools.Autofill
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class Address
    {
        /// <summary>
        /// fields and values defining an address.
        ///</summary>
        [JsonPropertyName("fields")]
        public AddressField[] Fields
        {
            get;
            set;
        }
    }
}