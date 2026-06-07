namespace Zu.ChromeDevTools.Memory
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// DOM object counter data.
    /// </summary>
    public sealed class DOMCounter
    {
        /// <summary>
        /// Object name. Note: object names should be presumed volatile and clients should not expect
        /// the returned names to be consistent across runs.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Object count.
        ///</summary>
        [JsonPropertyName("count")]
        public long Count
        {
            get;
            set;
        }
    }
}