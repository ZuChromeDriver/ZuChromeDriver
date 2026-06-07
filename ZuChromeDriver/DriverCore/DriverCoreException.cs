using System.Text.Json.Nodes;

namespace Zu.Chrome.DriverCore
{
    public class DriverCoreException : Exception
    {
        public string Error { get; set; }
        /// <summary>Text of a blocking JavaScript dialog when <see cref="Error"/> is <c>unexpected alert open</c>.</summary>
        public string AlertText { get; set; }
        public JsonNode Json { get; set; }
        private string stackTrace;
        /// <summary>
        /// When unset, fall back to the CLR stack so callers (and test runners) still see where the exception originated.
        /// </summary>
        public override string StackTrace => stackTrace ?? base.StackTrace;

        public DriverCoreException()
            : base()
        {

        }
        public DriverCoreException(string message)
            : base(message)
        {

        }

        public DriverCoreException(string message, string error)
            : base(message)
        {
            Error = error;
        }

        public DriverCoreException(JsonNode json)
            : this(json?["message"]?.ToString())
        {
            Json = json;
            Error = json?["error"]?.ToString();
            stackTrace = json?["stacktrace"]?.ToString();
        }

        public DriverCoreException SetStackTrace(string stackTrace)
        {
            this.stackTrace = stackTrace;
            return this;
        }
    }
}
