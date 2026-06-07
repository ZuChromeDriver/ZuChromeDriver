namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Response to an AuthChallenge.
    /// </summary>
    public sealed class AuthChallengeResponse
    {
        /// <summary>
        /// The decision on what to do in response to the authorization challenge.  Default means
        /// deferring to the default behavior of the net stack, which will likely either the Cancel
        /// authentication or display a popup dialog box.
        ///</summary>
        [JsonPropertyName("response")]
        public string Response
        {
            get;
            set;
        }
        /// <summary>
        /// The username to provide, possibly empty. Should only be set if response is
        /// ProvideCredentials.
        ///</summary>
        [JsonPropertyName("username")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Username
        {
            get;
            set;
        }
        /// <summary>
        /// The password to provide, possibly empty. Should only be set if response is
        /// ProvideCredentials.
        ///</summary>
        [JsonPropertyName("password")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Password
        {
            get;
            set;
        }
    }
}