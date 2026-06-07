namespace Zu.ChromeDevTools.DOMSnapshot
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class RareBooleanData
    {
        /// <summary>
        /// Gets or sets the index
        /// </summary>
        [JsonPropertyName("index")]
        public long[] Index
        {
            get;
            set;
        }
    }
}