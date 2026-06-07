namespace Zu.ChromeDevTools.Autofill
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Trigger autofill on a form identified by the fieldId.
    /// If the field and related form cannot be autofilled, returns an error.
    /// </summary>
    public sealed class TriggerCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Autofill.trigger";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// Identifies a field that serves as an anchor for autofill.
        /// </summary>
        [JsonPropertyName("fieldId")]
        public long FieldId
        {
            get;
            set;
        }
        /// <summary>
        /// Identifies the frame that field belongs to.
        /// </summary>
        [JsonPropertyName("frameId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// Credit card information to fill out the form. Credit card data is not saved.  Mutually exclusive with `address`.
        /// </summary>
        [JsonPropertyName("card")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CreditCard Card
        {
            get;
            set;
        }
        /// <summary>
        /// Address to fill out the form. Address data is not saved. Mutually exclusive with `card`.
        /// </summary>
        [JsonPropertyName("address")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Address Address
        {
            get;
            set;
        }
    }

    public sealed class TriggerCommandResponse : ICommandResponse<TriggerCommand>
    {
    }
}