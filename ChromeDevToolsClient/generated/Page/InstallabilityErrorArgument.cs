namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class InstallabilityErrorArgument
    {
        /// <summary>
        /// Argument name (e.g. name:'minimum-icon-size-in-pixels').
        ///</summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Argument value (e.g. value:'64').
        ///</summary>
        [JsonPropertyName("value")]
        public string Value
        {
            get;
            set;
        }
    }
}