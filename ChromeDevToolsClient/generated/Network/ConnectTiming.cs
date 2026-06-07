namespace Zu.ChromeDevTools.Network
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// 
    /// </summary>
    public sealed class ConnectTiming
    {
        /// <summary>
        /// Timing's requestTime is a baseline in seconds, while the other numbers are ticks in
        /// milliseconds relatively to this requestTime. Matches ResourceTiming's requestTime for
        /// the same request (but not for redirected requests).
        ///</summary>
        [JsonPropertyName("requestTime")]
        public double RequestTime
        {
            get;
            set;
        }
    }
}