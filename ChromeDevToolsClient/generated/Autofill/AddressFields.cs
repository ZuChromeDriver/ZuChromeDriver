namespace Zu.ChromeDevTools.Autofill
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// A list of address fields.
    /// </summary>
    public sealed class AddressFields
    {
        /// <summary>
        /// Gets or sets the fields
        /// </summary>
        [JsonPropertyName("fields")]
        public AddressField[] Fields
        {
            get;
            set;
        }
    }
}