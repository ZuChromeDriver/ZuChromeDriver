namespace Zu.ChromeDevTools.Page
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// The installability error
    /// </summary>
    public sealed class InstallabilityError
    {
        /// <summary>
        /// The error id (e.g. 'manifest-missing-suitable-icon').
        ///</summary>
        [JsonPropertyName("errorId")]
        public string ErrorId
        {
            get;
            set;
        }
        /// <summary>
        /// The list of error arguments (e.g. {name:'minimum-icon-size-in-pixels', value:'64'}).
        ///</summary>
        [JsonPropertyName("errorArguments")]
        public InstallabilityErrorArgument[] ErrorArguments
        {
            get;
            set;
        }
    }
}