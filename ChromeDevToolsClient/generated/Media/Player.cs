namespace Zu.ChromeDevTools.Media
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class Player
    {
        /// <summary>
        /// Gets or sets the playerId
        /// </summary>
        [JsonPropertyName("playerId")]
        public string PlayerId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the domNodeId
        /// </summary>
        [JsonPropertyName("domNodeId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public long? DomNodeId
        {
            get;
            set;
        }
    }
}