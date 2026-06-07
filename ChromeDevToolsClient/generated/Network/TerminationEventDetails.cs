namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Session event details specific to termination.
    /// </summary>
    public sealed class TerminationEventDetails
    {
        /// <summary>
        /// The reason for a session being deleted.
        ///</summary>
        [JsonPropertyName("deletionReason")]
        public string DeletionReason
        {
            get;
            set;
        }
    }
}