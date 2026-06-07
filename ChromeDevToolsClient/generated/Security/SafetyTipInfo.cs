namespace Zu.ChromeDevTools.Security
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class SafetyTipInfo
    {
        /// <summary>
        /// Describes whether the page triggers any safety tips or reputation warnings. Default is unknown.
        ///</summary>
        [JsonPropertyName("safetyTipStatus")]
        public SafetyTipStatus SafetyTipStatus
        {
            get;
            set;
        }
        /// <summary>
        /// The URL the safety tip suggested ("Did you mean?"). Only filled in for lookalike matches.
        ///</summary>
        [JsonPropertyName("safeUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string SafeUrl
        {
            get;
            set;
        }
    }
}