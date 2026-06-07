namespace Zu.ChromeDevTools.FedCm
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class DialogShownEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the dialogId
        /// </summary>
        [JsonPropertyName("dialogId")]
        public string DialogId
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the dialogType
        /// </summary>
        [JsonPropertyName("dialogType")]
        public DialogType DialogType
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the accounts
        /// </summary>
        [JsonPropertyName("accounts")]
        public Account[] Accounts
        {
            get;
            set;
        }
        /// <summary>
        /// These exist primarily so that the caller can verify the
        /// RP context was used appropriately.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the subtitle
        /// </summary>
        [JsonPropertyName("subtitle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Subtitle
        {
            get;
            set;
        }
    }
}