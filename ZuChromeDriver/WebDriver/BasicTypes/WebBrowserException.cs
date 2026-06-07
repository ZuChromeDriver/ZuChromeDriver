using System.Text.Json.Nodes;

namespace Zu.WebDriver.BasicTypes
{
    public class WebBrowserException: Exception
    {
        public string Error { get; set; }
        public JsonNode Json { get; set; }
        private string stackTrace;
        /// <summary>
        /// When unset, fall back to the CLR stack so callers (and test runners) still see where the exception originated.
        /// </summary>
        public override string StackTrace => stackTrace ?? base.StackTrace;

        public WebBrowserException()
            : base()
        {

        }
        public WebBrowserException(string message)
            :base(message)
        {

        }

        public WebBrowserException(string message, string error)
            : base(message)
        {
            Error = error;
        }

        public WebBrowserException(JsonNode json)
            :this(json?["message"]?.ToString())
        {
            Json = json;
            Error = json?["error"]?.ToString();
            stackTrace = json?["stacktrace"]?.ToString();
        }

        public WebBrowserException SetStackTrace(string stackTrace)
        {
            this.stackTrace = stackTrace;
            return this;
        }
    }
}
