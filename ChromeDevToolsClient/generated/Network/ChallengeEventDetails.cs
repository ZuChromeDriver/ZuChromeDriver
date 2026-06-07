namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Session event details specific to challenges.
    /// </summary>
    public sealed class ChallengeEventDetails
    {
        /// <summary>
        /// The result of a challenge.
        ///</summary>
        [JsonPropertyName("challengeResult")]
        public string ChallengeResult
        {
            get;
            set;
        }
        /// <summary>
        /// The challenge set.
        ///</summary>
        [JsonPropertyName("challenge")]
        public string Challenge
        {
            get;
            set;
        }
    }
}