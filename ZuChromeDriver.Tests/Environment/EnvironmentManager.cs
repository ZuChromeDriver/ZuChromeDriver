using System;
using System.Reflection;
using System.IO;
using Zu.WebDriver;

namespace Zu.ZuChromeDriver.Tests.Environment
{
    public class EnvironmentManager
    {
        private static readonly object ShutdownLock = new();
        private static EnvironmentManager _instance;
        private Zu.Chrome.ZuChromeDriver _ZuChromeDriver;
        private ZuWebDriver _driver;
        private UrlBuilder _urlBuilder;
        private TestWebServer _webServer;

        private EnvironmentManager()
        {
            _urlBuilder = new UrlBuilder();

            string currentDirectory = this.CurrentDirectory;
            DirectoryInfo info = new(currentDirectory);
            while (info != info.Root && string.Compare(info.Name, "ZuChromeDriver" /*"build"*/, StringComparison.OrdinalIgnoreCase) != 0)
            {
                info = info.Parent;
            }
            _webServer = new TestWebServer(info.FullName);
            _webServer.Start();
        }

        ~EnvironmentManager()
        {
            Shutdown();
        }

        public string CurrentDirectory
        {
            get
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                string assemblyLocation = executingAssembly.Location;
                if (string.IsNullOrEmpty(assemblyLocation))
                {
                    assemblyLocation = AppContext.BaseDirectory;
                }

                return Path.GetDirectoryName(assemblyLocation);
            }
        }
        
        public TestWebServer WebServer
        {
            get { return _webServer; }
        }

        public ZuWebDriver GetCurrentDriver()
        {
            if (_driver != null)
            { 
                return _driver; 
            }
            else 
            { 
                return CreateFreshDriver(); 
            }
        }

        /// <summary>
        /// Chrome options for E2E tests: popup blocking off by default.
        /// Enable <see cref="ChromeDriverConfig.EnableFrameTrackerOnConnect"/> per fixture or test when iframe/alert tracking is required.
        /// </summary>
        public static Zu.Chrome.ChromeDriverConfig CreateTestChromeConfig()
        {
            return new Zu.Chrome.ChromeDriverConfig
            {
                DisablePopupBlocking = true,
                // Suppresses native F7 "caret browsing" prompt during WebDriver key synthesis (FunctionKeys, etc.).
                CommandLineArguments = "--enable-automation --disable-features=CaretBrowsing",
            };
        }

        /// <summary>
        /// Additional browser instance for multi-window tests. Does not replace <see cref="GetCurrentDriver"/>.
        /// Caller must <see cref="IWebDriver.Quit"/> / <see cref="IDisposable.Dispose"/> when done.
        /// </summary>
        public ZuWebDriver CreateDriverInstance(bool enableFrameTracker = false)
        {
            var chromeConfig = CreateTestChromeConfig();
            if (enableFrameTracker)
                chromeConfig.EnableFrameTrackerOnConnect = true;
            return new ZuWebDriver(new Zu.Chrome.ZuChromeDriver(chromeConfig));
        }

        public ZuWebDriver CreateFreshDriver(bool enableFrameTracker = false)
        {
            CloseCurrentDriver();
            var chromeConfig = CreateTestChromeConfig();
            if (enableFrameTracker)
                chromeConfig.EnableFrameTrackerOnConnect = true;
            _ZuChromeDriver = new Zu.Chrome.ZuChromeDriver(chromeConfig);
            _driver = new ZuWebDriver(_ZuChromeDriver);
            return _driver;
        }

        public void CloseCurrentDriver()
        {
            if (_driver != null)
            {
                // Must shut down Chrome synchronously: fire-and-forget Close() lets the next
                // CreateFreshDriver race the old process/port and yield empty pages/titles.
                _driver.CloseSync();
                _driver = null;
                _ZuChromeDriver = null;
            }
        }

        public static EnvironmentManager Instance
        {
            get
            {
                _instance ??= new EnvironmentManager();

                return _instance;
            }
        }

        public static void Shutdown()
        {
            lock (ShutdownLock)
            {
                if (_instance == null)
                {
                    return;
                }

                _instance.CloseCurrentDriver();
                _instance._webServer?.Stop();
                _instance = null;
            }
        }

        public UrlBuilder UrlBuilder
        {
            get
            {
                return _urlBuilder;
            }
        }

    }
}
