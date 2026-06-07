namespace Zu.ChromeDevTools.Schema
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Description of the protocol domain.
    /// </summary>
    public sealed class Domain
    {
        /// <summary>
        /// Domain name.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Domain version.
        ///</summary>
        [JsonPropertyName("version")]
        public string Version
        {
            get;
            set;
        }
    }
}