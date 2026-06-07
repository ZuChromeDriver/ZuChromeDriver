namespace Zu.ChromeDevTools.FedCm
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Whether this is a sign-up or sign-in action for this account, i.e.
    /// whether this account has ever been used to sign in to this RP before.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LoginState
    {
        [JsonStringEnumMemberName("SignIn")]
        SignIn,
        [JsonStringEnumMemberName("SignUp")]
        SignUp,
    }
}