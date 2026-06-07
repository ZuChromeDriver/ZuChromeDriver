namespace Zu.ChromeDevTools.Runtime
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Issued when exception was thrown and unhandled.
    /// </summary>
    public sealed class ExceptionThrownEvent : IEvent
    {
        /// <summary>
        /// Timestamp of the exception.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public double Timestamp
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the exceptionDetails
        /// </summary>
        [JsonPropertyName("exceptionDetails")]
        public ExceptionDetails ExceptionDetails
        {
            get;
            set;
        }
    }
}