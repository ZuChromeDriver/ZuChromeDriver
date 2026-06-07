namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class CSSComputedStyleProperty
    {
        /// <summary>
        /// Computed style property name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Computed style property value.
        ///</summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
    }
}