namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class CorsErrorStatus
    {
        /// <summary>
        /// Gets or sets the corsError
        /// </summary>
        [JsonPropertyName("corsError")]
        public CorsError CorsError
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the failedParameter
        /// </summary>
        [JsonPropertyName("failedParameter")]
        public string FailedParameter
        {
            get;
            set;
        }
    }
}