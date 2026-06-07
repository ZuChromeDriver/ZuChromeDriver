namespace Zu.ChromeDevTools.Log
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Violation configuration setting.
    /// </summary>
    public sealed class ViolationSetting
    {
        /// <summary>
        /// Violation type.
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Time threshold to trigger upon.
        ///</summary>
        [JsonPropertyName("threshold")]
        public double Threshold
        {
            get;
            set;
        }
    }
}