namespace Zu.ChromeDevTools.CSS
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// CSS Layer data.
    /// </summary>
    public sealed class CSSLayerData
    {
        /// <summary>
        /// Layer name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Direct sub-layers
        ///</summary>
        [JsonPropertyName("subLayers")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public CSSLayerData[] SubLayers
        {
            get;
            set;
        }
        /// <summary>
        /// Layer order. The order determines the order of the layer in the cascade order.
        /// A higher number has higher priority in the cascade order.
        ///</summary>
        [JsonPropertyName("order")]
        public double Order
        {
            get;
            set;
        }
    }
}