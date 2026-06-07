namespace Zu.ChromeDevTools.Autofill
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Emitted when an address form is filled.
    /// </summary>
    public sealed class AddressFormFilledEvent : IEvent
    {
        /// <summary>
        /// Information about the fields that were filled
        /// </summary>
        [JsonPropertyName("filledFields")]
        public FilledField[] FilledFields
        {
            get;
            set;
        }
        /// <summary>
        /// An UI representation of the address used to fill the form.
        /// Consists of a 2D array where each child represents an address/profile line.
        /// </summary>
        [JsonPropertyName("addressUi")]
        public AddressUI AddressUi
        {
            get;
            set;
        }
    }
}