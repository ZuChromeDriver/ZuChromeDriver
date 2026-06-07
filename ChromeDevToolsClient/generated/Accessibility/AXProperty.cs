namespace Zu.ChromeDevTools.Accessibility
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class AXProperty
    {
        /// <summary>
        /// The name of this property.
        ///</summary>
        [JsonPropertyName("name")]
        public AXPropertyName Name
        {
            get;
            set;
        }
        /// <summary>
        /// The value of this property.
        ///</summary>
        [JsonPropertyName("value")]
        public AXValue Value
        {
            get;
            set;
        }
    }
}