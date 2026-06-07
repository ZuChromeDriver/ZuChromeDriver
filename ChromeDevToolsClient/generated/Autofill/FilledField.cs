namespace Zu.ChromeDevTools.Autofill
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class FilledField
    {
        /// <summary>
        /// The type of the field, e.g text, password etc.
        ///</summary>
        [JsonPropertyName("htmlType")]
        public string HtmlType
        {
            get;
            set;
        }
        /// <summary>
        /// the html id
        ///</summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get;
            set;
        }
        /// <summary>
        /// the html name
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// the field value
        ///</summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
        /// <summary>
        /// The actual field type, e.g FAMILY_NAME
        ///</summary>
        [JsonPropertyName("autofillType")]
        public string AutofillType
        {
            get;
            set;
        }
        /// <summary>
        /// The filling strategy
        ///</summary>
        [JsonPropertyName("fillingStrategy")]
        public FillingStrategy FillingStrategy
        {
            get;
            set;
        }
        /// <summary>
        /// The frame the field belongs to
        ///</summary>
        [JsonPropertyName("frameId")]
        public string FrameId
        {
            get;
            set;
        }
        /// <summary>
        /// The form field's DOM node
        ///</summary>
        [JsonPropertyName("fieldId")]
        public long FieldId
        {
            get;
            set;
        }
    }
}