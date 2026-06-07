namespace Zu.ChromeDevTools.Fetch
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Continues a request supplying authChallengeResponse following authRequired event.
    /// </summary>
    public sealed class ContinueWithAuthCommand : ICommand
    {
        private const string ChromeRemoteInterface_CommandName = "Fetch.continueWithAuth";
        
        [JsonIgnore]
        public string CommandName
        {
            get { return ChromeRemoteInterface_CommandName; }
        }

        /// <summary>
        /// An id the client received in authRequired event.
        /// </summary>
        [JsonPropertyName("requestId")]
        public string RequestId
        {
            get;
            set;
        }
        /// <summary>
        /// Response to  with an authChallenge.
        /// </summary>
        [JsonPropertyName("authChallengeResponse")]
        public AuthChallengeResponse AuthChallengeResponse
        {
            get;
            set;
        }
    }

    public sealed class ContinueWithAuthCommandResponse : ICommandResponse<ContinueWithAuthCommand>
    {
    }
}