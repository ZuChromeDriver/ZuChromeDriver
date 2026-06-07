namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Representation of a custom property registration through CSS.registerProperty
    /// </summary>
    public sealed class CSSPropertyRegistration
    {
        /// <summary>
        /// Gets or sets the propertyName
        /// </summary>
        [JsonPropertyName("propertyName")]
        public string PropertyName
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the initialValue
        /// </summary>
        [JsonPropertyName("initialValue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Value InitialValue
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the inherits
        /// </summary>
        [JsonPropertyName("inherits")]
        public bool Inherits
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the syntax
        /// </summary>
        [JsonPropertyName("syntax")]
        public string Syntax
        {
            get;
            set;
        }
    }
}